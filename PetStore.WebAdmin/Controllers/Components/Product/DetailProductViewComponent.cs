using Microsoft.AspNetCore.Mvc;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components.Product
{
    public class DetailProductViewComponent : ViewComponent
    {
        public DetailProductViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(ProductModel model)
        {
            return View(model);
        }
    }
}