namespace RxAuto.Services.Models.Departments
{
    using RxAuto.Services.Models.Phones;
    using System.Collections.Generic;

    public class DepartmentInfoServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // TODO: Add ImageUrl

        public IEnumerable<PhoneServiceModel> Phones { get; set; }
    }
}
