namespace RxAuto.Web.ViewModels.Documents.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for listing a JobPosition's information such as <c>Id</c> and <c>Name</c>.
    /// </summary>
    public class DocumentViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Документ")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        // TODO: Add services to view foreach document
    }
}
