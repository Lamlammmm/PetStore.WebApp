using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public interface IProductApiClient
    {
        Task<ApiResult<Pagination<ProductModel>>> GetPaging(ProductSearchModel request);

        Task<ApiResult<ProductModel>> GetById(Guid id);

        Task<ApiResult<int>> DeletesAsync(Guid ids);

        Task<ApiResult<IList<VoucherCodeModel>>> GetAll();
    }
}