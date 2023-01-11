using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public class MenuItemApiClient : BaseApiClient, IMenuItemApiClient
    {
        public MenuItemApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public async Task<ApiResult<int>> Create(MenuItemModel request)
        {
            var data = await PostAsync($"/api/MenuItem/Create-MenuItem", request);
            return data;
        }

        public async Task<ApiResult<int>> DeletesAsync(Guid ids)
        {
            var data = await Delete($"/api/MenuItem/Delete-MenuItem?id={ids}");
            return data;
        }

        public async Task<ApiResult<int>> Edit(MenuItemModel request)
        {
            var data = await PutAsync($"/api/MenuItem/Update-MenuItem", request);
            return data;
        }

        public async Task<ApiResult<IList<MenuItemModel>>> GetAll()
        {
            var data = await GetListAsync<MenuItemModel>($"/api/MenuItem/get-all");
            return data;
        }

        public async Task<ApiResult<MenuItemModel>> GetById(Guid id)
        {
            var data = await GetAsync<MenuItemModel>($"/api/MenuItem/get-by-id?id={id}");
            return data;
        }

        public async Task<ApiResult<Pagination<MenuItemModel>>> GetPaging(MenuItemSearchModel request)
        {
            var data = await GetPagingAsync<ApiResult<Pagination<MenuItemModel>>>($"/api/MenuItem/Get-All-Paging?Keyword={request.Keyword}&PageIndex={request.PageIndex}&PageSize={request.PageSize}");
            return data;
        }
    }
}