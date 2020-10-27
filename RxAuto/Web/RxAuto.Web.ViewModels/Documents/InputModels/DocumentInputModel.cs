namespace RxAuto.Web.ViewModels.Documents.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class DocumentInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Моля въвдете Документ")]
        [StringLength(300, ErrorMessage = "Документа трябва да е между 5 и 20 символа", MinimumLength = 5)]
        [Display(Name = "Документ", Prompt = "Документ")]
        public string DocumentName { get; set; }

        [MaxLength(4000)]
        [Display(Name = "Описание", Prompt = "Описание")]
        public string DocumentDescription { get; set; }
    }
}
