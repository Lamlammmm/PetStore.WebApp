using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.ApiClient;
using PetStore.Model;

namespace PetStore.WebAdmin.Controllers.Components.Product
{
    public class CreateProductViewComponent : ViewComponent
    {
        private readonly IProductApiClient _productApiClient;

        public CreateProductViewComponent(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new ProductModel();
            await GetDropDownList(model);
            return View(model);
        }

        private async Task GetDropDownList(ProductModel model)
        {
            //size
            var availableIndustry = await _productApiClient.GetAll();
            var role = new List<SelectListItem>();
            var dataRole = availableIndustry;
            if (dataRole.Data != null)
            {
                foreach (var m in dataRole.Data)
                {
                    var item = new SelectListItem
                    {
                        Text = $"{m.code} - {m.dieukien}",
                        Value = m.Id.ToString(),
                    };
                    role.Add(item);
                }
            }
            role.OrderBy(e => e.Text);
            if (role == null || role.Count == 0)
            {
                role = new List<SelectListItem>();
            }
            model.AvailableVote = new List<SelectListItem>(role);
        }
    }
}