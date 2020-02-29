namespace RxAuto.Data.Models
{
    public class ServiceOperatingLocation
    {
        //------------ Service [FK] -----------
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        //------------ OperatingLocation [FK] -----------
        public int OperatingLocationId { get; set; }
        public OperatingLocation OperatingLocation { get; set; }
    }
}
