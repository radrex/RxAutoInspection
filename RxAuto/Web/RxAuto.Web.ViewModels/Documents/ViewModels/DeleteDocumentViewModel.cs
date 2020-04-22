namespace RxAuto.Web.ViewModels.Documents.ViewModels
{
    /// <summary>
    /// View model for Document delete confirmation data such as <c>Id</c>, <c>Name</c> and <c>Description</c>.
    /// </summary>
    public class DeleteDocumentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
