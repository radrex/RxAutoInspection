namespace RxAuto.Data.Models
{
    public class ServiceVehicleType
    {
        //------------ Service [FK] -----------
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        //------------ VehicleType [FK] -----------
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
    }
}
