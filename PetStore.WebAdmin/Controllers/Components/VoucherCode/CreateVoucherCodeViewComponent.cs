using Microsoft.AspNetCore.Mvc;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components.VoucherCode
{
    public class CreateVoucherCodeViewComponent : ViewComponent
    {
        public CreateVoucherCodeViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new VoucherCodeModel();
            return View(model);
        }
    }
}