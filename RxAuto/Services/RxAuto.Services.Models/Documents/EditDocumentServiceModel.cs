namespace RxAuto.Services.Models.Documents
{
    /// <summary>
    /// Service model for Document edit information with <c>Id</c>, <c>Name</c> and <c>Description</c>.
    /// </summary>
    public class EditDocumentServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
