namespace RxAuto.Services.Models.OperatingLocations
{
    using RxAuto.Services.Models.Departments;
    using System.Collections.Generic;

    /// <summary>
    /// Service model for listing a OperatingLocation's information such as <c>Id</c>, <c>Town</c>, <c>Address</c> and a collection of <c>Departments</c>.
    /// </summary>
    public class OperatingLocationInfoServiceModel
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }

        // TODO: Add ImageUrl
        public IEnumerable<DepartmentInfoServiceModel> Departments { get; set; }
    }
}
