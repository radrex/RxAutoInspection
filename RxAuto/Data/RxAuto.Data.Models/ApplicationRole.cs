namespace RxAuto.Data.Models
{
    using RxAuto.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    using System;

    public class ApplicationRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        //------------- CONSTRUCTORS --------------
        public ApplicationRole() : this(null)
        {

        }

        public ApplicationRole(string name) : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        //-------------- PROPERTIES ---------------
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
