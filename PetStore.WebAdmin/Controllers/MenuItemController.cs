using Microsoft.AspNetCore.Mvc;
using PetStore.ApiClient;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers
{
    public class MenuItemController : BaseController
    {
        private readonly IMenuItemApiClient _menuItemApiClient;

        public MenuItemController(IMenuItemApiClient menuItemApiClient)
        {
            _menuItemApiClient = menuItemApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageSize = 10)
        {
            var request = new MenuItemSearchModel()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize
            };
            var data = await _menuItemApiClient.GetPaging(request);

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
            return ViewComponent("CreateMenuItem");
        }

        [HttpPost]
        public async Task<IActionResult> Create(MenuItemModel request)
        {
            request.panID = Guid.NewGuid().ToString();
            request.Id = Guid.NewGuid();
            var result = await _menuItemApiClient.Create(request);
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
            var result = await _menuItemApiClient.GetById(id);

            if (result.Data != null)
            {
                var model = result.Data;
                var updateRequest = new MenuItemModel()
                {
                    Id = id,
                    ghortOrder = model.ghortOrder,
                    icon = model.icon,
                    menuName = model.menuName,
                    panID = model.panID
                };
                return ViewComponent("EditMenuItem", updateRequest);
            }
            return RedirectToAction("Index", "MenuItem");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MenuItemModel request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _menuItemApiClient.Edit(request);
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
            var result = await _menuItemApiClient.DeletesAsync(id);

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
            var result = await _menuItemApiClient.GetById(id);
            if (result.Data != null)
            {
                var model = result.Data;
                var detailRequest = new MenuItemModel()
                {
                    Id = id,
                    ghortOrder = model.ghortOrder,
                    icon = model.icon,
                    menuName = model.menuName,
                    panID = model.panID
                };
                return ViewComponent("DetailMenuItem", detailRequest);
            }
            return RedirectToAction("Index", "MenuItem");
        }
    }
}