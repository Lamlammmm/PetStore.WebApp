using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public interface IProductDetailApiClient
    {
        Task<ApiResult<int>> CreateProductDetail(ProductModel request);

        Task<ApiResult<int>> EditProductDetail(ProductModel request);
    }
}