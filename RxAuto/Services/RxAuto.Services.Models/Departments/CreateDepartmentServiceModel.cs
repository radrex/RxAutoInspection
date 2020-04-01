namespace RxAuto.Services.Models.Departments
{
    using RxAuto.Services.Models.Phones;
    using System.Collections.Generic;

    /// <summary>
    /// Service model for Creating a Department with <c>Name</c>, <c>Email</c>, <c>Description</c> and IEnumerable&lt;<see cref="PhonesDropdownServiceModel"/>&gt;.
    /// <para>Each <see cref="PhonesDropdownServiceModel"/> contains Phone's <c>Id</c> and <c>PhoneNumber</c> properties.</para>
    /// </summary>
    public class CreateDepartmentServiceModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public IEnumerable<PhonesDropdownServiceModel> PhoneNumbers { get; set; }
    }
}
