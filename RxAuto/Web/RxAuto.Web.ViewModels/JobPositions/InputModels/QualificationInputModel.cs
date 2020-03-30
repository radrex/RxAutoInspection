namespace RxAuto.Web.ViewModels.JobPositions.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class QualificationInputModel
    {
        [Display(Name = "Qualification")]
        [Required(ErrorMessage = "Please enter Qualification name")]
        [StringLength(300, ErrorMessage = "Name should be 5-300 characters long", MinimumLength = 5)]
        public string QualificationName { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }
    }
}
