using Microsoft.AspNetCore.Mvc;

namespace PetStore.WebAdmin.Controllers.Components
{
    public class LogoutViewComponent : ViewComponent
    {
        private readonly ILogger<InfoAccountViewComponent> _logger;

        public LogoutViewComponent(ILogger<InfoAccountViewComponent> logger)
        {
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}