namespace RxAuto.Services.Models.Services
{
    using RxAuto.Services.Models.Documents;
    using RxAuto.Services.Models.OperatingLocations;

    using System.Collections.Generic;

    /// <summary>
    /// Service model for Creating a Service with <c>ServiceTypeId</c>, <c>VehicleTypeId</c>, <c>Name</c>, <c>Description</c>, <c>IsShownInSubMenu</c>, <c>Price</c> and collections of <c>OperatingLocations</c> and <c>Documents</c>.
    /// </summary>
    public class CreateServiceServiceModel
    {
        public int ServiceTypeId { get; set; }
        public int VehicleTypeId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public bool IsShownInSubMenu { get; set; }
        public decimal Price { get; set; }

        public IEnumerable<OperatingLocationsDropdownServiceModel> OperatingLocations { get; set; }
        public IEnumerable<DocumentsDropdownServiceModel> Documents { get; set; }
    }
}
