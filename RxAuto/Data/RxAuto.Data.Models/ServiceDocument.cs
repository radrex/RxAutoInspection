namespace RxAuto.Data.Models
{
    public class ServiceDocument
    {
        //------------ Service [FK] -----------
        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        //------------ Document [FK] -----------
        public int DocumentId { get; set; }
        public virtual Document Document { get; set; }
    }
}
