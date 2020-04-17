namespace RxAuto.Services.Models.Employees
{
    /// <summary>
    /// Service model for Employee edit information with <c>Id</c>, <c>JobPositionId</c>, <c>OperatingLocationId</c>, <c>FirstName</c>, <c>MiddleName</c>, <c>LastName</c>, <c>Phone</c>, <c>Email</c>, <c>Town</c>, <c>Address</c> and <c>ImageUrl</c>.
    /// </summary>
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
