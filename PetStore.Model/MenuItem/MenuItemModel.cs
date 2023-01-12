using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.Common.ShareModel;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Model
{
    public class MenuItemModel : BaseEntityModel
    {
        [Display(Name = "Tên chức năng")]
        public string menuName { get; set; }

        [Display(Name = "Sắp xếp")]
        public int ghortOrder { get; set; }

        [Display(Name = "Danh mục cha")]
        public string panID { get; set; }

        [Display(Name = "Icon")]
        public string icon { get; set; }

        [Display(Name = "Loại chức năng")]
        public string typeMenu { get; set; }

        [Display(Name = "Loại chức năng")]
        public string? typeMenuName { get; set; }

        public IList<SelectListItem>? AvailabletypeMenu { get; set; }
    }
}