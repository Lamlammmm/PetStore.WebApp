using Microsoft.AspNetCore.Mvc;
using PetStore.Model;
using PetStore.WebApiClient;

namespace PetStore.Web.Controllers.Components.BannerOffer
{
    public class BannerOfferViewComponent : ViewComponent
    {
        private readonly ILogger<BannerOfferViewComponent> _logger;
        private readonly IUnBannerApiClient _unBannerApiClient;

        public BannerOfferViewComponent(ILogger<BannerOfferViewComponent> logger, IUnBannerApiClient unBannerApiClient)
        {
            _logger = logger;
            _unBannerApiClient = unBannerApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            _logger.LogInformation("Get SetCookie");
            var about = await _unBannerApiClient.GetBannerOffer();
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
                        Title = m.Title,
                        Image = m.Image,
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