namespace RxAuto.Data.Models
{
    public class TownService
    {
        //------------ Town [FK] -----------
        public int TownId { get; set; }
        public Town Town { get; set; }

        //------------ Document [FK] -----------
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
