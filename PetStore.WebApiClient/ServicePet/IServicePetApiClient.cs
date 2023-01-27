using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.WebApiClient
{
    public interface IServicePetApiClient
    {
        Task<ApiResult<IList<ServicePetModel>>> GetServicePetHome();
    }
}