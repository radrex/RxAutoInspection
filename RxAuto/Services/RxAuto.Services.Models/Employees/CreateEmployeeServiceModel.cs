namespace RxAuto.Services.Models.Employees
{
    /// <summary>
    /// Service model for Creating an Employee with <c>JobPositionId</c> and <c>OperatingLocationId</c> and other credentials.
    /// </summary>
    public class CreateEmployeeServiceModel
    {
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
