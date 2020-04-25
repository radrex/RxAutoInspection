namespace RxAuto.Web.ViewModels.Employees.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for Employee information with <c>Id</c>, <c>FullName</c>, <c>PhoneNumber</c>, <c>Email</c>, <c>HomeAddress</c>, <c>ImageUrl</c>, <c>OperatingLocation</c> and <c>JobPosition</c>.
    /// </summary>
    public class EmployeeDetailsViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Име")]
        public string FullName { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Имейл")]
        public string Email { get; set; }

        [Display(Name = "Адрес")]
        public string HomeAddress { get; set; }

        [Display(Name = "Линк към снимка")]
        public string ImageUrl { get; set; }

        [Display(Name = "Работна Локация")]
        public string OperatingLocation { get; set; }

        [Display(Name = "Работна Позиция")]
        public string JobPosition { get; set; }
    }
}
