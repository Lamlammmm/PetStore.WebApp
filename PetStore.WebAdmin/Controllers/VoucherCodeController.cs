using Microsoft.AspNetCore.Mvc;
using PetStore.ApiClient;
using PetStore.Common.System;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers
{
    public class VoucherCodeController : BaseController
    {
        private readonly IVoucherCodeApiClient _voucherCodeApiClient;

        public VoucherCodeController(IVoucherCodeApiClient voucherCodeApiClient)
        {
            _voucherCodeApiClient = voucherCodeApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new VoucherCodeSearchModel()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _voucherCodeApiClient.GetPaging(request);

            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.Data);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return ViewComponent("CreateVoucherCode");
        }

        [HttpPost]
        public async Task<IActionResult> Create(VoucherCodeModel request)
        {
            request.Id = Guid.NewGuid();
            request.code = ExtensionFull.GetCodeMemberScheme("MCH");
            var result = await _voucherCodeApiClient.Create(request);
            if (result.Data > 0)
            {
                TempData["success"] = result.Message;
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _voucherCodeApiClient.GetById(id);

            if (result.Data != null)
            {
                var model = result.Data;
                var updateRequest = new VoucherCodeModel()
                {
                    Id = id,
                    code = model.code,
                    dieukien = model.dieukien
                };
                return ViewComponent("EditVoucherCode", updateRequest);
            }
            return RedirectToAction("Index", "VoucherCode");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VoucherCodeModel request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _voucherCodeApiClient.Edit(request);
            if (result.Data > 0)
            {
                TempData["info"] = result.Message;
                return RedirectToAction("Index");
            }
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _voucherCodeApiClient.DeletesAsync(id);

            if (result.Data > 0)
            {
                TempData["result"] = result.Message;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var result = await _voucherCodeApiClient.GetById(id);
            if (result.Data != null)
            {
                var model = result.Data;
                var detailRequest = new VoucherCodeModel()
                {
                    Id = id,
                    code = model.code,
                    dieukien = model.dieukien
                };
                return ViewComponent("DetailVoucherCode", detailRequest);
            }
            return RedirectToAction("Index", "VoucherCode");
        }
    }
}