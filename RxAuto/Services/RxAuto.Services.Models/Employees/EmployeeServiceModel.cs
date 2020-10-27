namespace RxAuto.Services.Models.Employees
{
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
