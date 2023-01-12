using Microsoft.AspNetCore.Mvc;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components.About
{
    public class CreateAboutViewComponent : ViewComponent
    {
        public CreateAboutViewComponent()
        {
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new AboutModel();
            return View(model);
        }
    }
}