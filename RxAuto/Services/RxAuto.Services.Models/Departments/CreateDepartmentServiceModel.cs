namespace RxAuto.Services.Models.Departments
{
    using RxAuto.Services.Models.Phones;
    using System.Collections.Generic;

    public class CreateDepartmentServiceModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public IEnumerable<PhonesDropdownServiceModel> PhoneNumbers { get; set; }
    }
}
