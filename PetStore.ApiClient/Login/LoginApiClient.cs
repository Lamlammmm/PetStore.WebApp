using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public class LoginApiClient : BaseApiClient, ILoginApiClient
    {
        public LoginApiClient(IHttpClientFactory httpClientFactory,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
            : base(httpClientFactory, configuration, httpContextAccessor)
        {
        }

        public async Task<ApiResult<string>> Login(LoginModel request)
        {
            var data = await Authenticate($"/api/login/authenticate", request);
            return data;
        }
    }
}