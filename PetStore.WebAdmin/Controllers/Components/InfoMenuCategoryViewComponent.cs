using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetStore.ApiClient;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components
{
    [Authorize]
    public class InfoMenuCategoryViewComponent : ViewComponent
    {
        private readonly ILogger<InfoMenuCategoryViewComponent> _logger;
        private readonly IMenuItemApiClient _menuItemApiClient;

        public InfoMenuCategoryViewComponent(ILogger<InfoMenuCategoryViewComponent> logger,
            IMenuItemApiClient menuItemApiClient)
        {
            _logger = logger;
            _menuItemApiClient = menuItemApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            _logger.LogInformation("Get SetCookie ");
            var noti = await _menuItemApiClient.GetMenuItemCategory();

            var categories = new List<MenuItemModel>();
            var data = noti;

            if (data.Data?.Count > 0)
            {
                foreach (var m in data.Data)
                {
                    var item = new MenuItemModel
                    {
                        menuName = m.menuName
                    };
                    categories.Add(item);
                }
            }

            _logger.LogInformation("End get SetCookie");
            return View(categories);
        }
    }
}