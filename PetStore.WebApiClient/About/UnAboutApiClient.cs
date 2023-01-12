using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.WebApiClient
{
    public class UnAboutApiClient : UnauthorizedBaseApiClient, IUnAboutApiClient
    {
        public UnAboutApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public async Task<ApiResult<IList<AboutModel>>> GetAboutIndex()
        {
            var data = await GetListAsync<AboutModel>($"/api/about/get-all-index");
            return data;
        }
    }
}