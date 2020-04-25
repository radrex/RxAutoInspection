namespace RxAuto.Web.ViewModels.Employees.InputModels
{
    using RxAuto.Web.ViewModels.JobPositions.ViewModels;
    using RxAuto.Web.ViewModels.OperatingLocations.ViewModels;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Input model for entering Employee information from the user. 
    /// It includes <c>JobPositionId</c>, a collection of <c>JobPositions</c>, <c>OperatingLocationId</c>, a collection of <c>OperatingLocations</c>, 
    /// <c>FirstName</c>, <c>FirstName</c>, <c>MiddleName</c>, <c>LastName</c>, <c>Phone</c>, <c>Email</c>, <c>Town</c>, <c>Address</c> and <c>ImageUrl</c>.
    /// Validation on User-Side is also included via attributes.
    /// </summary>
    public class EmployeeInputModel
    {
        public string Id { get; set; }

        [Display(Name = "Работна Позиция", Prompt = "Работна Позиция")]
        [Required(ErrorMessage = "Моля въвдете Работна Позиция")]
        [Range(100, int.MaxValue)]
        public int JobPositionId { get; set; }
        public IEnumerable<JobPositionsDropdownViewModel> JobPositions { get; set; }


        [Display(Name = "Работна Локация", Prompt = "Работна Локация")]
        [Required(ErrorMessage = "Моля въвдете Работна Локация")]
        [Range(10, int.MaxValue)]
        public int OperatingLocationId { get; set; }
        public IEnumerable<OperatingLocationsDropdownViewModel> OperatingLocations { get; set; }


        [Display(Name = "Име", Prompt = "Име")]
        [Required(ErrorMessage = "Моля въведете Име")]
        [StringLength(20, ErrorMessage = "Името трябва да бъде между 2 и 20 символа", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Презиме", Prompt = "Презиме")]
        [Required(ErrorMessage = "Моля въведете Презиме")]
        [StringLength(20, ErrorMessage = "Презимето трябва да бъде между 2 и 20 символа", MinimumLength = 2)]
        public string MiddleName { get; set; }

        [Display(Name = "Фамилия", Prompt = "Фамилия")]
        [Required(ErrorMessage = "Моля въведете Фамилия")]
        [StringLength(20, ErrorMessage = "Фамилията трябва да бъде между 2 и 20 символа", MinimumLength = 2)]
        public string LastName { get; set; }

        [Display(Name = "Телефон", Prompt = "Телефон")]
        [Required(ErrorMessage = "Моля въведете Телефон")]
        [RegularExpression(@"^([+]?359)|0?(|-| )8[789]\d{1}(|-| )\d{3}(|-| )\d{3}$", ErrorMessage = "Невалиден Телефон")]
        [MaxLength(15)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Моля въведете Имейл")]
        [MaxLength(254)]
        [Display(Name = "Имейл", Prompt = "Имейл")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Невалиден Имейл")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Моля въведете Град")]
        [StringLength(30, ErrorMessage = "Града трябва да бъде между 3 и 30 символа", MinimumLength = 3)]
        [Display(Name = "Град", Prompt = "Град")]
        public string Town { get; set; }

        [Required(ErrorMessage = "Моля въведете Адрес")]
        [StringLength(50, ErrorMessage = "Адреса трябва да бъде между 8 и 50 символа", MinimumLength = 8)]
        [Display(Name = "Адрес", Prompt = "Адрес")]
        public string Address { get; set; }

        [MaxLength(2000)]
        [Display(Name = "Линк към снимка", Prompt = "Линк към снимка")]
        public string ImageUrl { get; set; }
    }
}
