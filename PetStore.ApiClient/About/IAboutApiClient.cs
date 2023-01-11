using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public interface IAboutApiClient
    {
        Task<ApiResult<Pagination<AboutModel>>> GetPaging(AboutSearchModel request);

        Task<ApiResult<AboutModel>> GetById(Guid id);

        Task<ApiResult<int>> DeletesAsync(Guid ids);
    }
}