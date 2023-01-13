using Microsoft.AspNetCore.Mvc;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components.Banner
{
    public class EditBannerViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(BannerModel model)
        {
            return View(model);
        }
    }
}