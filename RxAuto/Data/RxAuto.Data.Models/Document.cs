namespace RxAuto.Data.Models
{
    using static DataValidation.DataValidation.MediaInfo;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Document
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }

        [Required]
        [MaxLength(DocumentNameMaxLength)]
        public string Name { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        //------------ ServiceDocument [FK] MAPPING TABLE -----------
        public virtual ICollection<ServiceDocument> Services { get; set; } = new HashSet<ServiceDocument>();
    }
}
