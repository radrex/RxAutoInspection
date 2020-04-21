namespace RxAuto.Services.Models.Departments
{
    /// <summary>
    /// Service model for Department edit information with <c>Id</c>, <c>Name</c>, <c>Email</c>, <c>Description</c> and a collection of <c>PhoneNumberIds</c>.
    /// </summary>
    public class EditDepartmentServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int[] PhoneNumberIds { get; set; }
    }
}
