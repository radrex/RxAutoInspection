namespace RxAuto.Services.Models.Departments
{
    /// <summary>
    /// Service model for listing an Department's <c>Id</c>, <c>Name</c> and <c>Email</c>.
    /// </summary>
    public class DepartmentsListingServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
