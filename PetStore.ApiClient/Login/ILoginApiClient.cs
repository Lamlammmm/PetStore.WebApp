using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public interface ILoginApiClient
    {
        Task<ApiResult<string>> Login(LoginModel request);
    }
}