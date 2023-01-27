using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public class ServicePetApiClient : BaseApiClient, IServicePetApiClient
    {
        public ServicePetApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public async Task<ApiResult<int>> Create(ServicePetModel request)
        {
            var data = await PostAsync($"/api/ServicePet/Create-ServicePet", request);
            return data;
        }

        public async Task<ApiResult<int>> DeletesAsync(Guid ids)
        {
            var data = await Delete($"/api/ServicePet/Delete-ServicePet?id={ids}");
            return data;
        }

        public async Task<ApiResult<int>> Edit(ServicePetModel request)
        {
            var data = await PutAsync($"/api/ServicePet/Update-ServicePet", request);
            return data;
        }

        public async Task<ApiResult<ServicePetModel>> GetById(Guid id)
        {
            var data = await GetAsync<ServicePetModel>($"/api/ServicePet/get-by-id?id={id}");
            return data;
        }

        public async Task<ApiResult<Pagination<ServicePetModel>>> GetPaging(ServicePetSearchModel request)
        {
            var data = await GetPagingAsync<ApiResult<Pagination<ServicePetModel>>>($"/api/ServicePet/Get-All-Paging?Keyword={request.Keyword}&PageIndex={request.PageIndex}&PageSize={request.PageSize}");
            return data;
        }
    }
}