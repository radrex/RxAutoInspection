namespace RxAuto.Web.ViewModels.Documents.ViewModels
{
    /// <summary>
    /// View model for Document information with <c>Id</c>, <c>Name</c> and <c>Description</c>.
    /// </summary>
    public class DocumentDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
