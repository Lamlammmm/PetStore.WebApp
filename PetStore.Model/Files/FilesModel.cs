using Microsoft.AspNetCore.Http;
using PetStore.Common.ShareModel;

namespace PetStore.Model
{
    public class FilesModel : BaseEntityModel
    {
        public string FileName { get; set; }
        public string? Path { get; set; }
        public decimal Size { get; set; }
        public string? Extension { get; set; }
        public string? MimeType { get; set; }
        public Guid AboutId { get; set; }

        public IFormFile? filesadd { get; set; }
    }
}