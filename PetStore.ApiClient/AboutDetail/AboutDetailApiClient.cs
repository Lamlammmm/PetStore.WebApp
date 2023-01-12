using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public class AboutDetailApiClient : BaseApiClient, IAboutDetailApiClient
    {
        public AboutDetailApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public async Task<ApiResult<int>> Create(AboutDetailModel request)
        {
            var data = await PostAsync($"/api/AboutDetail/Create-AboutDetail", request);
            return data;
        }

        public async Task<ApiResult<int>> Edit(AboutDetailModel request)
        {
            var data = await PutAsync($"/api/AboutDetail/Update-AboutDetail", request);
            return data;
        }
    }
}