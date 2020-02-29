namespace RxAuto.Data.Models
{
    public class Contact
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        //------------ OperatingLocation [FK] -----------
        public int OperatingLocationId { get; set; }
        public OperatingLocation OperatingLocation { get; set; }
    }
}
