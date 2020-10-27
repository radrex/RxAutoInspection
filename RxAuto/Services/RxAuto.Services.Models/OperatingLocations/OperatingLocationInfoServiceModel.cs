namespace RxAuto.Services.Models.OperatingLocations
{
    using RxAuto.Services.Models.Departments;
    using System.Collections.Generic;

    public class OperatingLocationInfoServiceModel
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }

        // TODO: Add ImageUrl
        public IEnumerable<DepartmentInfoServiceModel> Departments { get; set; }
    }
}
