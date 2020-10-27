namespace RxAuto.Web.ViewModels.Documents.ViewModels
{
    using System.ComponentModel.DataAnnotations;

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
