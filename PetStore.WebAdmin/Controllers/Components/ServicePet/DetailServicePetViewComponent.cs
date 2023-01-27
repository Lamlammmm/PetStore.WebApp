using Microsoft.AspNetCore.Mvc;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components.ServicePet
{
    public class DetailServicePetViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ServicePetModel model)
        {
            return View(model);
        }
    }
}