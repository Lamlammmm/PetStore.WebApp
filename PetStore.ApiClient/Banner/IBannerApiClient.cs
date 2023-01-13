using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public interface IBannerApiClient
    {
        Task<ApiResult<Pagination<BannerModel>>> GetPaging(BannerSearchModel request);

        Task<ApiResult<BannerModel>> GetById(Guid id);

        Task<ApiResult<int>> DeletesAsync(Guid ids);

        Task<ApiResult<BannerModel>> Create();
    }
}