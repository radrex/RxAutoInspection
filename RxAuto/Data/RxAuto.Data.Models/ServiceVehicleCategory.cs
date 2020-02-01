namespace RxAuto.Data.Models
{
    public class ServiceVehicleCategory
    {
        //------------ Service [FK] -----------
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        //------------ VehicleCategory [FK] -----------
        public int VehicleCategoryId { get; set; }
        public VehicleCategory VehicleCategory { get; set; }
    }
}
