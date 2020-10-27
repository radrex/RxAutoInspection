namespace RxAuto.Services.Models.Employees
{
    public class EditEmployeeServiceModel
    {
        public string Id { get; set; }
        public int JobPositionId { get; set; }
        public int OperatingLocationId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }
    }
}
