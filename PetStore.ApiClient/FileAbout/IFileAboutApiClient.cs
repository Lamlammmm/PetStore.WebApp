using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public interface IFileAboutApiClient
    {
        public Task<bool> CreateImage(FilesModel request, Guid id);

        Task<ApiResult<int>> CreateAbout(AboutModel request);

        Task<ApiResult<int>> EditAbout(AboutModel request);

        Task<bool> DeleteFiles(Guid id);

        public Task<bool> UpdateImage(FilesModel request, Guid id);

        Task<List<FilesModel>> GetFilesAdmin(Guid id);

        Task<bool> DeleteDataFiles(Guid id);
    }
}