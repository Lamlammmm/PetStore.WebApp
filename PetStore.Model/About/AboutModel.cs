using Microsoft.AspNetCore.Http;
using PetStore.Common.ShareModel;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Model
{
    public class AboutModel : BaseEntityModel
    {
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }

        [Display(Name = "Loại bài viết")]
        public string CatagoryDetail { get; set; }

        [Display(Name = "Chi tiết bài viết")]
        public string ContenDetail { get; set; }

        public Guid AboutId { get; set; }

        public IFormFile? filesadd { get; set; }

        public List<FilesModel>? FilesModels { get; set; }

    }
}