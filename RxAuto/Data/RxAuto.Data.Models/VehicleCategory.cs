namespace RxAuto.Data.Models
{
    using RxAuto.Data.Models.Enums;
    using System.Collections.Generic;

    public class VehicleCategory
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public VehicleCategoryType Category { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        //------------ Vehicle [FK] -----------
        public ICollection<Vehicle> Vehicles { get; set; } = new HashSet<Vehicle>();

        //------------ ServiceVehicleCategory [FK] MAPPING TABLE -----------
        public ICollection<ServiceVehicleCategory> Services { get; set; } = new HashSet<ServiceVehicleCategory>();

    }
}
