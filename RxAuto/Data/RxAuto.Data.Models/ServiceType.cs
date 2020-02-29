namespace RxAuto.Data.Models
{
    using System.Collections.Generic;

    public class ServiceType
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsInDevelopment { get; set; }
        public string Description { get; set; }

        //------------ Service [FK] -----------
        public ICollection<Service> Services { get; set; } = new HashSet<Service>();
    }
}
