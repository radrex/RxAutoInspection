namespace RxAuto.Services.Models.Documents
{
    /// <summary>
    /// Service model for listing an Document's <c>Id</c>, <c>Name</c> and <c>Description</c>.
    /// </summary>
    public class DocumentsListingServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
