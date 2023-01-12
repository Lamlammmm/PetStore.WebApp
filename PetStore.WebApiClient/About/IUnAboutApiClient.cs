using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.WebApiClient
{
    public interface IUnAboutApiClient
    {
        Task<ApiResult<IList<AboutModel>>> GetAboutIndex();
    }
}