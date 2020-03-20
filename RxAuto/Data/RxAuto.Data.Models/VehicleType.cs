namespace RxAuto.Data.Models
{
    using Enums;
    using static DataValidation.DataValidation.MediaInfo;
    using static DataValidation.DataValidation.VehicleInfo;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class VehicleType
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }

        [Required]
        [MaxLength(VehicleTypeName)]
        public string Name { get; set; }

        public VehicleCategory VehicleCategory { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        //------------ ServiceVehicleType [FK] MAPPING TABLE -----------
        public virtual ICollection<ServiceVehicleType> Services { get; set; } = new HashSet<ServiceVehicleType>();
    }
}
