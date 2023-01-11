using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public class AboutApiClient : BaseApiClient, IAboutApiClient
    {
        public AboutApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public async Task<ApiResult<int>> DeletesAsync(Guid ids)
        {
            var data = await Delete($"/api/About/Delete-About?id={ids}");
            return data;
        }

        public async Task<ApiResult<AboutModel>> GetById(Guid id)
        {
            var data = await GetAsync<AboutModel>($"/api/About/get-by-id?id={id}");
            return data;
        }

        public async Task<ApiResult<Pagination<AboutModel>>> GetPaging(AboutSearchModel request)
        {
            var data = await GetPagingAsync<ApiResult<Pagination<AboutModel>>>($"/api/About/Get-All-Paging?Keyword={request.Keyword}&PageIndex={request.PageIndex}&PageSize={request.PageSize}");
            return data;
        }
    }
}