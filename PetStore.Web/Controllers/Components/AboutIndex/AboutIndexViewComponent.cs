using Microsoft.AspNetCore.Mvc;
using PetStore.Model;
using PetStore.WebApiClient;

namespace PetStore.Web.Controllers.Components.AboutIndex
{
    public class AboutIndexViewComponent : ViewComponent
    {
        private readonly ILogger<AboutIndexViewComponent> _logger;
        private readonly IUnAboutApiClient _aboutApiClient;

        public AboutIndexViewComponent(ILogger<AboutIndexViewComponent> logger,
            IUnAboutApiClient aboutApiClient)
        {
            _logger = logger;
            _aboutApiClient = aboutApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            _logger.LogInformation("Get SetCookie ");
            var about = await _aboutApiClient.GetAboutIndex();

            var model = new List<AboutModel>();
            var data = about;

            if (data.Data?.Count > 0)
            {
                foreach (var m in data.Data)
                {
                    var item = new AboutModel
                    {
                        AboutId = m.AboutId,
                        CatagoryDetail = m.CatagoryDetail,
                        ContenDetail = m.ContenDetail,
                        Content = m.Content,
                        Id = m.Id,
                        Image = m.Image,
                        Title = m.Title,
                    };
                    model.Add(item);
                }
            }

            _logger.LogInformation("End get SetCookie");
            return View(model);
        }
    }
}