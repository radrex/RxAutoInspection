namespace RxAuto.Web.ViewModels.Qualifications.InputModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Input model for entering Qualification information from the user. It includes <c>QualificationName</c> and <c>Description</c>.
    /// Validation on User-Side is also included via attributes.
    /// </summary>
    public class QualificationInputModel
    {
        public int Id { get; set; }

        [Display(Name = "Квалификация", Prompt = "Квалификация")]
        [Required(ErrorMessage = "Моля въведете Квалификация")]
        [StringLength(300, ErrorMessage = "Квалификацията трябва да бъде между 5 и 300 символа", MinimumLength = 5)]
        public string QualificationName { get; set; }

        [MaxLength(4000)]
        [Display(Name = "Описание", Prompt = "Описание")]
        public string Description { get; set; }
    }
}
