using Microsoft.AspNetCore.Mvc;
using PetStore.Model;
using PetStore.WebApiClient;

namespace PetStore.Web.Controllers.Components.BannerHome
{
    public class BannerHomeViewComponent : ViewComponent
    {
        private readonly ILogger<BannerHomeViewComponent> _logger;
        private readonly IUnBannerApiClient _unBannerApiClient;

        public BannerHomeViewComponent(ILogger<BannerHomeViewComponent> logger,
            IUnBannerApiClient unBannerApiClient)
        {
            _logger = logger;
            _unBannerApiClient = unBannerApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            _logger.LogInformation("Get SetCookie ");
            var about = await _unBannerApiClient.GetBannerHome();

            var model = new List<BannerModel>();
            var data = about;

            if (data.Data?.Count > 0)
            {
                foreach (var m in data.Data)
                {
                    var item = new BannerModel
                    {
                        Content = m.Content,
                        Id = m.Id,
                        Image = m.Image,
                        Title = m.Title,
                        TypeBanner = m.TypeBanner
                    };
                    model.Add(item);
                }
            }

            _logger.LogInformation("End get SetCookie");
            return View(model);
        }
    }
}