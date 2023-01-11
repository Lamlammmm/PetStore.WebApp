using PetStore.Common.XBaseModel;
using PetStore.Model;

namespace PetStore.ApiClient
{
    public interface IMenuItemApiClient
    {
        Task<ApiResult<Pagination<MenuItemModel>>> GetPaging(MenuItemSearchModel request);

        Task<ApiResult<MenuItemModel>> GetById(Guid id);

        Task<ApiResult<int>> DeletesAsync(Guid ids);

        Task<ApiResult<IList<MenuItemModel>>> GetAll();

        Task<ApiResult<int>> Create(MenuItemModel request);

        Task<ApiResult<int>> Edit(MenuItemModel request);
    }
}