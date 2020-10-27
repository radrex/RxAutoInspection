namespace RxAuto.Services.Models.Departments
{
    public class DepartmentServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public int[] PhoneNumberIds { get; set; }
    }
}
