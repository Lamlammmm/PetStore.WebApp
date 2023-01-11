using PetStore.Common.ShareModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

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
    }
}