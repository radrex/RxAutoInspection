namespace RxAuto.Services.Models.Documents
{
    /// <summary>
    /// Service model for Creating a Document with <c>Name</c> and <c>Description</c>.
    /// </summary>
    public class CreateDocumentServiceModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
