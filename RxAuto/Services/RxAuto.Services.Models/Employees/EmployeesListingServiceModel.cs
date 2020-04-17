namespace RxAuto.Services.Models.Employees
{
    /// <summary>
    /// Service model for listing an Employee's <c>Id</c>, <c>FirstName</c>, <c>MiddleName</c>, <c>LastName</c>, <c>PhoneNumber</c>, <c>Email</c>, <c>OperatingLocationTown</c>, <c>OperatingLocationAddress</c> and <c>JobPosition</c>.
    /// </summary>
    public class EmployeesListingServiceModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string OperatingLocationTown { get; set; }
        public string OperatingLocationAddress { get; set; }
        public string JobPosition { get; set; }
    }
}
