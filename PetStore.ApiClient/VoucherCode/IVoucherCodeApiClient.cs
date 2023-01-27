using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public interface IVoucherCodeApiClient
    {
        Task<ApiResult<Pagination<VoucherCodeModel>>> GetPaging(VoucherCodeSearchModel request);

        Task<ApiResult<VoucherCodeModel>> GetById(Guid id);

        Task<ApiResult<int>> DeletesAsync(Guid ids);

        Task<ApiResult<int>> Create(VoucherCodeModel request);

        Task<ApiResult<int>> Edit(VoucherCodeModel request);
    }
}