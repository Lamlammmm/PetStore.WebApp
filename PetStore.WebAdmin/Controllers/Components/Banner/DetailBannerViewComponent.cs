using Microsoft.AspNetCore.Mvc;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components.Banner
{
    public class DetailBannerViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(BannerModel model)
        {
            return View(model);
        }
    }
}