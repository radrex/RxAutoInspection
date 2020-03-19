namespace RxAuto.Data.Models
{
    public class ServiceVehicleType
    {
        //------------ Service [FK] -----------
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        //------------ VehicleType [FK] -----------
        public int VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }
    }
}
