using Microsoft.AspNetCore.Mvc;
using PetStore.ApiClient;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers
{
    public class ServicePetController : BaseController
    {
        private readonly IServicePetApiClient _servicePetApiClient;

        public ServicePetController(IServicePetApiClient servicePetApiClient)
        {
            _servicePetApiClient = servicePetApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new ServicePetSearchModel()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _servicePetApiClient.GetPaging(request);

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
            return ViewComponent("CreateServicePet");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServicePetModel request)
        {
            request.Id = Guid.NewGuid();
            var result = await _servicePetApiClient.Create(request);
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
            var result = await _servicePetApiClient.GetById(id);

            if (result.Data != null)
            {
                var model = result.Data;
                var updateRequest = new ServicePetModel()
                {
                    Id = id,
                    title = model.title,
                    icon = model.icon,
                    content = model.content
                };
                return ViewComponent("EditServicePet", updateRequest);
            }
            return RedirectToAction("Index", "ServicePet");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ServicePetModel request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _servicePetApiClient.Edit(request);
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
            var result = await _servicePetApiClient.DeletesAsync(id);

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
            var result = await _servicePetApiClient.GetById(id);
            if (result.Data != null)
            {
                var model = result.Data;
                var detailRequest = new ServicePetModel()
                {
                    Id = id,
                    title = model.title,
                    icon = model.icon,
                    content = model.content
                };
                return ViewComponent("DetailServicePet", detailRequest);
            }
            return RedirectToAction("Index", "ServicePet");
        }
    }
}