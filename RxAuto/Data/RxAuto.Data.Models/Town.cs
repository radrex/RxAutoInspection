namespace RxAuto.Data.Models
{
    using System.Collections.Generic;

    public class Town
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public string Name { get; set; }


        //------------ Employee [FK] -----------
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

        //------------ Reservation [FK] -----------
        public ICollection<Reservation> Reservations { get; set; } = new HashSet<Reservation>();


        //------------ TownService [FK] MAPPING TABLE -----------
        public ICollection<TownService> Services { get; set; } = new HashSet<TownService>();

    }
}
