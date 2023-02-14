using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public class VoucherCodeApiClient : BaseApiClient, IVoucherCodeApiClient
    {
        public VoucherCodeApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public async Task<ApiResult<int>> Create(VoucherCodeModel request)
        {
            var data = await PostAsync($"/api/VoucherCode/Create-VoucherCode", request);
            return data;
        }

        public async Task<ApiResult<int>> DeletesAsync(Guid ids)
        {
            var data = await Delete($"/api/VoucherCode/Delete-VoucherCode?id={ids}");
            return data;
        }

        public async Task<ApiResult<int>> Edit(VoucherCodeModel request)
        {
            var data = await PutAsync($"/api/VoucherCode/Update-VoucherCode", request);
            return data;
        }

        public async Task<ApiResult<VoucherCodeModel>> GetById(Guid id)
        {
            var data = await GetAsync<VoucherCodeModel>($"/api/VoucherCode/get-by-id?id={id}");
            return data;
        }

        public async Task<ApiResult<Pagination<VoucherCodeModel>>> GetPaging(VoucherCodeSearchModel request)
        {
            var data = await GetPagingAsync<ApiResult<Pagination<VoucherCodeModel>>>($"/api/VoucherCode/Get-All-Paging?Keyword={request.Keyword}&PageIndex={request.PageIndex}&PageSize={request.PageSize}");
            return data;
        }
    }
}