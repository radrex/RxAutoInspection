namespace RxAuto.Web.ViewModels.Documents.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for Document information with <c>Id</c>, <c>Name</c> and <c>Description</c>.
    /// </summary>
    public class DocumentDetailsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Документ")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
