using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public class BannerApiClient : BaseApiClient, IBannerApiClient
    {
        public BannerApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public async Task<ApiResult<int>> DeletesAsync(Guid ids)
        {
            var data = await Delete($"/api/Banner/Delete-Banner?id={ids}");
            return data;
        }

        public async Task<ApiResult<BannerModel>> GetById(Guid id)
        {
            var data = await GetAsync<BannerModel>($"/api/Banner/get-by-id?id={id}");
            return data;
        }

        public async Task<ApiResult<Pagination<BannerModel>>> GetPaging(BannerSearchModel request)
        {
            var data = await GetPagingAsync<ApiResult<Pagination<BannerModel>>>($"/api/Banner/Get-All-Paging?Keyword={request.Keyword}&PageIndex={request.PageIndex}&PageSize={request.PageSize}");
            return data;
        }

        public async Task<ApiResult<BannerModel>> Create()
        {
            var data = await GetAsync<BannerModel>($"/api/Banner/create");
            return data;
        }
    }
}