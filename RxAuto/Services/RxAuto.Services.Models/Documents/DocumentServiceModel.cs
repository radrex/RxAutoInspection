namespace RxAuto.Services.Models.Documents
{
    /// <summary>
    /// Service model for Document information with <c>Id</c>, <c>Name</c> and <c>Description</c>.
    /// </summary>
    public class DocumentServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
