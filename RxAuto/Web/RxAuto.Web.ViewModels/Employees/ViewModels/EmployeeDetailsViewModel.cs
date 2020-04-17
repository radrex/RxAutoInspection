namespace RxAuto.Web.ViewModels.Employees.ViewModels
{
    /// <summary>
    /// View model for Employee information with <c>Id</c>, <c>FullName</c>, <c>PhoneNumber</c>, <c>Email</c>, <c>HomeAddress</c>, <c>ImageUrl</c>, <c>OperatingLocation</c> and <c>JobPosition</c>.
    /// </summary>
    public class EmployeeDetailsViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string ImageUrl { get; set; }
        public string OperatingLocation { get; set; }
        public string JobPosition { get; set; }
    }
}
