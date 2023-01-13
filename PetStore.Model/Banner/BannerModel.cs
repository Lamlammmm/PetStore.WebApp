using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.Common.ShareModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PetStore.Model
{
    public class BannerModel : BaseEntityModel
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }

        [Display(Name = "Loại quảng cáo")]
        public string TypeBanner { get; set; }

        [Display(Name = "Loại quảng cáo")]
        public string? TypeBannerName { get; set; }
        public IFormFile? filesadd { get; set; }
        public IList<SelectListItem>? AvailableTypeBanner { get; set; }
        public List<FilesModel>? FilesModels { get; set; }
    }
}