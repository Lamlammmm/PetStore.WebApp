using PetStore.Common.ShareModel;

namespace PetStore.Model
{
    public class ServicePetModel : BaseEntityModel
    {
        public string title { get; set; }
        public string icon { get; set; }
        public string content { get; set; }
    }
}