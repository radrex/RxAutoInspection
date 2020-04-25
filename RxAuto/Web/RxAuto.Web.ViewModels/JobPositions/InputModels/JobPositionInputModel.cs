﻿namespace RxAuto.Web.ViewModels.JobPositions.InputModels
{
    using RxAuto.Web.ViewModels.Qualifications.ViewModels;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Input model for entering JobPosition information from the user. It includes <c>JobPositionName</c>, array of <c>QualificationIds</c> and a collection of <c>Qualifications</c>.
    /// Validation on User-Side is also included via attributes.
    /// </summary>
    public class JobPositionInputModel
    {
        public int Id { get; set; }

        [Display(Name = "Работна Позиция", Prompt = "Работна Позиция")]
        [Required(ErrorMessage = "Моля въведете Работна Позиция")]
        [StringLength(150, ErrorMessage = "Работната позиция трябва да бъде между 5 и 150 символа", MinimumLength = 5)]
        public string JobPositionName { get; set; }

        //For multiple Id's passed from <select>
        [Display(Name = "Изберете квалификации")]
        public int[] QualificationIds { get; set; }

        public IEnumerable<QualificationsDropdownViewModel> Qualifications { get; set; }
    }
}
