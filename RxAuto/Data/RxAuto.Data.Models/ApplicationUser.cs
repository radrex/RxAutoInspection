namespace RxAuto.Data.Models
{
    using RxAuto.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    using System;
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        //------------- CONSTRUCTORS --------------
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Reservations = new HashSet<Reservation>();
        }

        public ApplicationUser(string username) : this()
        {
            this.UserName = username;
        }

        //-------------- PROPERTIES ---------------
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        //------------ Reservation [FK] -----------
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
