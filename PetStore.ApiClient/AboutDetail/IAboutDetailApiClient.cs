using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public interface IAboutDetailApiClient
    {
        Task<ApiResult<int>> Create(AboutDetailModel request);

        Task<ApiResult<int>> Edit(AboutDetailModel request);
    }
}