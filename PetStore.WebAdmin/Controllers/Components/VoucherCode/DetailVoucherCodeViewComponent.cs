using Microsoft.AspNetCore.Mvc;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components.VoucherCode
{
    public class DetailVoucherCodeViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(VoucherCodeModel model)
        {
            return View(model);
        }
    }
}