namespace PetStore.Common.ShareModel
{
    public class SearchModel
    {
        public string? Keyword { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}