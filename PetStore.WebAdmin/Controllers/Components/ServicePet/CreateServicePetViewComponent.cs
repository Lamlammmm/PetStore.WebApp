using Microsoft.AspNetCore.Mvc;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components.ServicePet
{
    public class CreateServicePetViewComponent : ViewComponent
    {
        public CreateServicePetViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new ServicePetModel();
            return View(model);
        }
    }
}