using Microsoft.AspNetCore.Mvc;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components.Product
{
    public class EditProductViewComponent : ViewComponent
    {
        public EditProductViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(ProductModel model)
        {
            return View(model);
        }
    }
}