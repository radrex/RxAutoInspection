namespace RxAuto.Services.Models.OperatingLocations
{
    using RxAuto.Services.Models.Departments;
    using System.Collections.Generic;

    /// <summary>
    /// Service model for Creating an OperatingLocation with <c>Town</c>, <c>Address</c>, <c>Description</c>, <c>ImageUrl</c> and IEnumerable&lt;<see cref="DepartmentsDropdownServiceModel"/>&gt;.
    /// <para>Each <see cref="DepartmentsDropdownServiceModel"/> contains OperatingLocation's <c>Id</c>, <c>Name</c>, <c>Email</c> and a collection of <c>Phones</c></para>
    /// </summary>
    public class CreateOperatingLocationServiceModel
    {
        public string Town { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<DepartmentsDropdownServiceModel> Departments { get; set; }
    }
}
