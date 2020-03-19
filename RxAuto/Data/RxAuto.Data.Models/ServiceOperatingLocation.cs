namespace RxAuto.Data.Models
{
    public class ServiceOperatingLocation
    {
        //------------ Service [FK] -----------
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        //------------ OperatingLocation [FK] -----------
        public int OperatingLocationId { get; set; }
        public virtual OperatingLocation OperatingLocation { get; set; }
    }
}
