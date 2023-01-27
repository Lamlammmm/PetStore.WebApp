using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.WebApiClient
{
    public class ServicePetApiClient : UnauthorizedBaseApiClient, IServicePetApiClient
    {
        public ServicePetApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public async Task<ApiResult<IList<ServicePetModel>>> GetServicePetHome()
        {
            var data = await GetListAsync<ServicePetModel>($"/api/ServicePet/Get-List-Service-home");
            return data;
        }
    }
}