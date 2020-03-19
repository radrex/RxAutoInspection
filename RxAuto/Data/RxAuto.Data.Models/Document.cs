namespace RxAuto.Data.Models
{
    using System.Collections.Generic;

    public class Document
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //------------ ServiceDocument [FK] MAPPING TABLE -----------
        public virtual ICollection<ServiceDocument> Services { get; set; } = new HashSet<ServiceDocument>();
    }
}
