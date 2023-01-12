using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.ApiClient;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components.MenuItem
{
    public class CreateMenuItemViewComponent : ViewComponent
    {
        private readonly IMenuItemApiClient _menuItemApiClient;
        public CreateMenuItemViewComponent(IMenuItemApiClient menuItemApiClient)
        {
            _menuItemApiClient = menuItemApiClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new MenuItemModel();
            var res = await _menuItemApiClient.Create();
            model = res.Data;
            await GetDropDownList(model);
            return View(model);
        }

        private async Task GetDropDownList(MenuItemModel model)
        {
            //size
            var availableIndustry = await _menuItemApiClient.Create();
            var role = new List<SelectListItem>();
            var dataRole = availableIndustry;
            if (dataRole.Data != null)
            {
                foreach (var m in dataRole.Data.AvailabletypeMenu)
                {
                    var item = new SelectListItem
                    {
                        Text = m.Text,
                        Value = m.Value,
                    };
                    role.Add(item);
                }
            }
            role.OrderBy(e => e.Text);
            if (role == null || role.Count == 0)
            {
                role = new List<SelectListItem>();
            }
            model.AvailabletypeMenu = new List<SelectListItem>(role);
        }
    }
}