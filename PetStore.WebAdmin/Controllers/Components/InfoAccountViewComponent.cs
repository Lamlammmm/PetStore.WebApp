using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PetStore.WebAdmin.Controllers.Components
{
    [Authorize]
    public class InfoAccountViewComponent : ViewComponent
    {
        private readonly ILogger<InfoAccountViewComponent> _logger;

        public InfoAccountViewComponent(ILogger<InfoAccountViewComponent> logger)
        {
            _logger = logger;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}