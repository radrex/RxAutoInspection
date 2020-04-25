namespace RxAuto.Web.ViewModels.Departments.InputModels
{
    using RxAuto.Web.ViewModels.Phones.ViewModels;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Input model for entering Department information from the user. It includes <c>Name</c>, <c>Email</c>, <c>Description</c>, array of <c>PhoneNumberIds</c> and a collection of <c>PhoneNumbers</c>.
    /// Validation on User-Side is also included via attributes.
    /// </summary>
    public class DepartmentInputModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Моля въвдете Отдел")]
        [StringLength(150, ErrorMessage = "Отдела трябва да е между 5 и 150 символа", MinimumLength = 5)]
        [Display(Name = "Отдел", Prompt = "Отдел")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Моля въвдете Имейл")]
        [MaxLength(254)]
        [Display(Name = "Имейл", Prompt = "Имейл")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Невалиден Имейл")]
        public string Email { get; set; }

        [MaxLength(4000)]
        [Display(Name = "Описание", Prompt = "Описание")]
        public string Description { get; set; }

        //For multiple Id's passed from <select>
        [Display(Name = "Избери телефони")]
        public int[] PhoneNumberIds { get; set; }

        public IEnumerable<PhonesDropdownViewModel> PhoneNumbers { get; set; }
    }
}
