namespace RxAuto.Web.ViewModels.OperatingLocations.InputModels
{
    using RxAuto.Web.ViewModels.Phones.ViewModels;
    using RxAuto.Web.ViewModels.Departments.ViewModels;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Input model for entering OperatingLocation information from the user. It includes <c>Town</c>, <c>Address</c>, <c>Description</c>, <c>ImageUrl</c>, array of <c>DepartmentIds</c> and a collection of <c>Departments</c>.
    /// Validation on User-Side is also included via attributes.
    /// </summary>
    public class OperatingLocationInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Моля въведете Град")]
        [StringLength(30, ErrorMessage = "Града трябва да бъде между 3 и 30 символа", MinimumLength = 3)]
        [Display(Name = "Град", Prompt = "Град")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Моля въведете Адрес")]
        [StringLength(50, ErrorMessage = "Адреса трябва да бъде между 10 и 50 символа", MinimumLength = 10)]
        [Display(Name = "Адрес", Prompt = "Адрес")]
        public string Address { get; set; }

        [MaxLength(4000)]
        [Display(Name = "Описание", Prompt = "Описание")]
        public string Description { get; set; }

        [MaxLength(2000)]
        [Display(Name = "Линк към снимка", Prompt = "Линк към снимка")]
        public string ImageUrl { get; set; }

        //First element is <Department ID, second element is Phone ID
        //For multiple Id's passed from <select>
        [Display(Name = "Изберете Отдели")]
        public string[] DepartmentIds { get; set; }
        public IEnumerable<DepartmentsDropdownViewModel> Departments { get; set; }
    }
}
