namespace RxAuto.Data.Models
{
    using RxAuto.Data.Models.Enums;
    using System.Collections.Generic;

    public class Document
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Description { get; set; }

        //------------ ServiceDocument [FK] MAPPING TABLE -----------
        public ICollection<ServiceDocument> Services { get; set; } = new HashSet<ServiceDocument>();

    }
}
