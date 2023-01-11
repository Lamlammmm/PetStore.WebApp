using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public interface IFileAboutApiClient
    {
        public Task<bool> CreateImage(FilesModel request, Guid id);

        Task<ApiResult<int>> CreateAbout(AboutModel request);
    }
}