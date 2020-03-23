﻿namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class ReservationsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Reservations.Any())
            {
                return;
            }

            var reservations = new List<(bool IsActive, string VehicleMake, string VehicleModel, string LicenseNumber, string PhoneNumber, DateTime ReservationTime, string ServiceName, string Username)>
            {
                (true, "BMW", "M3", "СА 1234 КР", "0897842017", new DateTime(2020, 06, 02, 12, 30, 0), "M1 - Лек автомобил", "GuestUser"),
                (true, "BMW", "Е36", "СА 5678 ВР", "0897860812", new DateTime(2020, 06, 02, 13, 0, 0), "M1 - Лек автомобил", "NormalUser"),
                (false, "Toyota", "Supra", "Е 7391 КР", "0897860812", new DateTime(2020, 07, 11, 9, 30, 0), "M1 - Лек автомобил", "NormalUser"),
            };

            foreach (var reservation in reservations)
            {
                Service service = dbContext.Services.FirstOrDefault(s => s.Name == reservation.ServiceName);
                ApplicationUser user = dbContext.Users.FirstOrDefault(u => u.UserName == reservation.Username);

                await dbContext.Reservations.AddAsync(new Reservation
                {
                    IsActive = reservation.IsActive,
                    VehicleMake = reservation.VehicleMake,
                    VehicleModel = reservation.VehicleModel,
                    LicenseNumber = reservation.LicenseNumber,
                    PhoneNumber = reservation.PhoneNumber,
                    ReservationDateTime = reservation.ReservationTime,
                    Service = service,
                    User = user,
                });
            }
        }
    }
}
