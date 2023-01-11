using Microsoft.AspNetCore.Mvc;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components.MenuItem
{
    public class DetailMenuItemViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(MenuItemModel model)
        {
            return View(model);
        }
    }
}