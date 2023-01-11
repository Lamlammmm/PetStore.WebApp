using Microsoft.AspNetCore.Mvc;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components.About
{
    public class DetailMenuItemViewComponent : ViewComponent
    {
        public DetailMenuItemViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(AboutModel model)
        {
            return View(model);
        }
    }
}