using PetStore.Common.ShareModel;

namespace PetStore.Model
{
    public class AboutDetailModel : BaseEntityModel
    {
        public string catagoryDetail { get; set; }
        public string contenDetail { get; set; }
        public Guid aboutId { get; set; }
    }
}