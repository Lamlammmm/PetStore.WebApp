using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.ApiClient;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components.Banner
{
    public class CreateBannerViewComponent : ViewComponent
    {
        private readonly IBannerApiClient _bannerApiClient;

        public CreateBannerViewComponent(IBannerApiClient bannerApiClient)
        {
            _bannerApiClient = bannerApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new BannerModel();
            var res = await _bannerApiClient.Create();
            model = res.Data;
            await GetDropDownList(model);
            return View(model);
        }

        private async Task GetDropDownList(BannerModel model)
        {
            //size
            var availableIndustry = await _bannerApiClient.Create();
            var role = new List<SelectListItem>();
            var dataRole = availableIndustry;
            if (dataRole.Data != null)
            {
                foreach (var m in dataRole.Data.AvailableTypeBanner)
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
            model.AvailableTypeBanner = new List<SelectListItem>(role);
        }
    }
}