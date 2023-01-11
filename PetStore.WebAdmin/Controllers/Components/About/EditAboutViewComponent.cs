using Microsoft.AspNetCore.Mvc;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components.About
{
    public class EditAboutViewComponent : ViewComponent
    {
        public EditAboutViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(AboutModel model)
        {
            return View(model);
        }
    }
}