namespace RxAuto.Web.ViewModels.Employees.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for listing an Employee's information such as <c>Id</c>, <c>FullName</c>, <c>PhoneNumber</c>, <c>Email</c>, <c>OperatingLocation</c> and <c>JobPosition</c>.
    /// </summary>
    public class EmployeeViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [Display(Name = "Operating Location")]
        public string OperatingLocation { get; set; }

        [Display(Name = "Job Position")]
        public string JobPosition { get; set; }
    }
}
