namespace RxAuto.Services.Models.Services
{
    using RxAuto.Services.Models.Documents;
    using RxAuto.Services.Models.OperatingLocations;

    using System.Collections.Generic;

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
