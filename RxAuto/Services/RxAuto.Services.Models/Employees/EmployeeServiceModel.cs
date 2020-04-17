namespace RxAuto.Services.Models.Employees
{
    /// <summary>
    /// Service model for Employee information with <c>Id</c>, <c>FirstName</c>, <c>MiddleName</c>, <c>LastName</c>, <c>FullName</c>, <c>PhoneNumber</c>, <c>Email</c>, <c>Town</c>, <c>Address</c>, <c>HomeAddress</c>, <c>ImageUrl</c>, <c>OperatingLocation</c> and <c>JobPosition</c>.
    /// </summary>
    public class EmployeeServiceModel
    {
        public int JobPositionId { get; set; }
        public string JobPosition { get; set; }

        public int OperatingLocationId { get; set; }
        public string OperatingLocation { get; set; }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public string HomeAddress { get; set; }
        public string ImageUrl { get; set; }
    }
}
