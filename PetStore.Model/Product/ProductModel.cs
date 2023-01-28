using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetStore.Common.ShareModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PetStore.Model
{
    public class ProductModel : BaseEntityModel
    {
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Giá")]
        public int Price { get; set; }

        [Display(Name = "Hình ảnh chi tiết")]
        public string? ImageDetail { get; set; }

        [Display(Name = "Nội dung")]
        public string? Content { get; set; }

        [Display(Name = "Voucher")]
        public Guid? VoteId { get; set; }

        [Display(Name = "Voucher")]
        public string? VoteName { get; set; }

        public IList<SelectListItem>? AvailableVote { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        public int? PriceDetail { get; set; }

        [Display(Name = "Số lượng")]
        public int? Qualyti { get; set; }
        public Guid ProductId { get; set; }
        public IFormFile? filesadd { get; set; }

        public List<FilesModel>? FilesModels { get; set; }
    }
}
