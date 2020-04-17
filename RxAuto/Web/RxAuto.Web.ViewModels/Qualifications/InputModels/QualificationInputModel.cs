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

        [Display(Name = "Qualification")]
        [Required(ErrorMessage = "Please enter Qualification name")]
        [StringLength(300, ErrorMessage = "Name should be 5-300 characters long", MinimumLength = 5)]
        public string QualificationName { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }
    }
}
