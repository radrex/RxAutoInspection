namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;
    using RxAuto.Data.Seeding.JSONSeed;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    public class ReservationsSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly List<JReservation> reservations;

        //------------- CONSTRUCTORS --------------
        public ReservationsSeeder(List<JReservation> reservations)
        {
            this.reservations = reservations;
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Reservations.Any())
            {
                return;
            }

            foreach (JReservation reservation in this.reservations)
            {
                UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                ApplicationUser user = await userManager.FindByNameAsync(reservation.Username);

                await dbContext.Reservations.AddAsync(new Reservation
                {
                    IsActive = reservation.IsActive,
                    VehicleMake = reservation.VehicleMake,
                    VehicleModel = reservation.VehicleModel,
                    LicenseNumber = reservation.LicenseNumber,
                    PhoneNumber = reservation.PhoneNumber,
                    ReservationDateTime = reservation.ReservationDateTime,
                    ServiceId = reservation.ServiceId,
                    User = user,
                    OperatingLocationId = reservation.OperatingLocationId,
                });

                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(
            }
        }
    }
}
