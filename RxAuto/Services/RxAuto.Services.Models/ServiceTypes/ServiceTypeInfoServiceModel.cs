namespace RxAuto.Services.Models.ServiceTypes
{
    using RxAuto.Services.Models.Services;
    using System.Collections.Generic;

    /// <summary>
    /// Service model for ServiceType information with <c>Id</c>, <c>Name</c>, <c>Description</c>, <c>IsShownInMainMenu</c> and a collection of <c>Services</c>.
    /// </summary>
    public class ServiceTypeInfoServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsShownInMainMenu { get; set; }
        public IEnumerable<ServiceInfoServiceModel> Services { get; set; }
    }
}
