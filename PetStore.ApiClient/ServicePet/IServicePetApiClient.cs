using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public interface IServicePetApiClient
    {
        Task<ApiResult<Pagination<ServicePetModel>>> GetPaging(ServicePetSearchModel request);

        Task<ApiResult<ServicePetModel>> GetById(Guid id);

        Task<ApiResult<int>> DeletesAsync(Guid ids);

        Task<ApiResult<int>> Create(ServicePetModel request);

        Task<ApiResult<int>> Edit(ServicePetModel request);
    }
}