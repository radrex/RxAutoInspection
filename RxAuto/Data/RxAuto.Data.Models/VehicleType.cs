namespace RxAuto.Data.Models
{
    using RxAuto.Data.Models.Enums;

    using System.Collections.Generic;

    public class VehicleType
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public string Name { get; set; }
        public VehicleCategory VehicleCategory { get; set; }
        public string Description { get; set; }

        //------------ ServiceVehicleType [FK] MAPPING TABLE -----------
        public virtual ICollection<ServiceVehicleType> Services { get; set; } = new HashSet<ServiceVehicleType>();
    }
}
