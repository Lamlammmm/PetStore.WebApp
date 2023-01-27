using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        public ProductApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public async Task<ApiResult<int>> DeletesAsync(Guid ids)
        {
            var data = await Delete($"/api/Product/Delete-Product?id={ids}");
            return data;
        }

        public async Task<ApiResult<ProductModel>> GetById(Guid id)
        {
            var data = await GetAsync<ProductModel>($"/api/Product/get-by-id?id={id}");
            return data;
        }

        public async Task<ApiResult<Pagination<ProductModel>>> GetPaging(ProductSearchModel request)
        {
            var data = await GetPagingAsync<ApiResult<Pagination<ProductModel>>>($"/api/Product/Get-All-Paging?Keyword={request.Keyword}&PageIndex={request.PageIndex}&PageSize={request.PageSize}");
            return data;
        }
    }
}