using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.WebApiClient
{
    public interface IUnBannerApiClient
    {
        Task<ApiResult<IList<BannerModel>>> GetBannerHome();
    }
}