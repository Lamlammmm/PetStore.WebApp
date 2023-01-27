using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public interface IFileProductApiClient
    {
        public Task<bool> CreateImage(FilesModel request, Guid id);

        Task<ApiResult<int>> CreateProduct(ProductModel request);

        Task<ApiResult<int>> EditProduct(ProductModel request);

        Task<bool> DeleteFiles(Guid id);

        public Task<bool> UpdateImage(FilesModel request, Guid id);

        Task<List<FilesModel>> GetFilesAdmin(Guid id);

        Task<bool> DeleteDataFiles(Guid id);
    }
}