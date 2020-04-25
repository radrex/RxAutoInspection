namespace RxAuto.Web.ViewModels.Documents.InputModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Input model for entering Document information from the user. 
    /// It includes <c>DocumentName</c> and <c>DocumentDescription</c>.
    /// Validation on User-Side is also included via attributes.
    /// </summary>
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
