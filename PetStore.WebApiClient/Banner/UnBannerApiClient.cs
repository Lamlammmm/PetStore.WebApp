using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.WebApiClient
{
    public class UnBannerApiClient : UnauthorizedBaseApiClient, IUnBannerApiClient
    {
        public UnBannerApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public async Task<ApiResult<IList<BannerModel>>> GetBannerHome()
        {
            var data = await GetListAsync<BannerModel>($"/api/Banner/get-list");
            return data;
        }
    }
}