namespace RxAuto.Web.ViewModels.JobPositions.InputModels
{
    using RxAuto.Web.ViewModels.Qualifications.ViewModels;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class JobPositionInputModel
    {
        [Display(Name = "Job Position")]
        [Required(ErrorMessage = "Please enter Job Position name")]
        [StringLength(150, ErrorMessage = "Name should be 5 to 150 characters long", MinimumLength = 5)]
        public string JobPositionName { get; set; }

        //For multiple Id's passed from <select>
        [Display(Name = "Qualifications")]
        public int[] QualificationIds { get; set; }

        public IEnumerable<QualificationsListingViewModel> Qualifications { get; set; }
    }
}
