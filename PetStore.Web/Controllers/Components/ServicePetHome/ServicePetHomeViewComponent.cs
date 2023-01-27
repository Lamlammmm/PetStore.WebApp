using Microsoft.AspNetCore.Mvc;
using PetStore.Model;
using PetStore.WebApiClient;

namespace PetStore.Web.Controllers.Components.BannerHome
{
    public class ServicePetHomeViewComponent : ViewComponent
    {
        private readonly ILogger<ServicePetHomeViewComponent> _logger;
        private readonly IServicePetApiClient _servicePetApiClient;

        public ServicePetHomeViewComponent(ILogger<ServicePetHomeViewComponent> logger, 
            IServicePetApiClient servicePetApiClient)
        {
            _logger = logger;
            _servicePetApiClient = servicePetApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            _logger.LogInformation("Get SetCookie ");
            var about = await _servicePetApiClient.GetServicePetHome();

            var model = new List<ServicePetModel>();
            var data = about;

            if (data.Data?.Count > 0)
            {
                foreach (var m in data.Data)
                {
                    var item = new ServicePetModel
                    {
                        Id = m.Id,
                        title = m.title,
                        icon = m.icon,
                        content = m.content
                    };
                    model.Add(item);
                }
            }

            _logger.LogInformation("End get SetCookie");
            return View(model);
        }
    }
}