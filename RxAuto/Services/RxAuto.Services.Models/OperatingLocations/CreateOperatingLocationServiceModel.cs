namespace RxAuto.Services.Models.OperatingLocations
{
    using RxAuto.Services.Models.Departments;
    using System.Collections.Generic;

    public class CreateOperatingLocationServiceModel
    {
        public string Town { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<DepartmentsDropdownServiceModel> Departments { get; set; }
    }
}
