namespace RxAuto.Data.Models
{
    using static DataValidation.DataValidation.MediaInfo;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ServiceType
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsShownInMainMenu{ get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        //------------ Service [FK] -----------
        public virtual ICollection<Service> Services { get; set; } = new HashSet<Service>();
    }
}
