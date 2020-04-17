namespace RxAuto.Web.ViewModels.Qualifications.ViewModels
{
    /// <summary>
    /// View model for Qualification delete confirmation data such as <c>Id</c>, <c>Name</c> and <c>Description</c>.
    /// </summary>
    public class DeleteQualificationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
