namespace RxAuto.Services.Data.Tests
{
    using RxAuto.Data;
    using RxAuto.Data.Models;
    using RxAuto.Services.Data.Implementations;

    using Xunit;
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Threading.Tasks;
    using RxAuto.Services.Models.Qualifications;
    using System.Collections.Generic;
    using RxAuto.Services.Data;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using RxAuto.Services.Models.Reservations;

    public class ReservationTests
    {
        [Fact]
        public void Count_ReturnsCorrectCount()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Reservation reservation = new Reservation()
                {
                    VehicleMake = "BMW",
                    VehicleModel = "M5",
                    LicenseNumber = "СА 1234 КР",
                    PhoneNumber = "0897482124",
                    ReservationDateTime = new DateTime(2020, 3, 21, 10, 30, 10),
                };

                dbContext.Reservations.Add(reservation);
                dbContext.SaveChanges();

                var reservationsService = new ReservationsService(dbContext);
                int reservationsCount = reservationsService.Count();

                Assert.Equal(1, reservationsCount);
            }
        }

        [Fact]
        public void Exist_ReturnsTrue()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Reservation reservation = new Reservation()
                {
                    VehicleMake = "BMW",
                    VehicleModel = "M5",
                    LicenseNumber = "СА 1234 КР",
                    PhoneNumber = "0897482124",
                    ReservationDateTime = new DateTime(2020, 3, 21, 10, 30, 10),
                };


                dbContext.Reservations.Add(reservation);
                dbContext.SaveChanges();

                var reservationsService = new ReservationsService(dbContext);
                var result = reservationsService.Exists(reservation.Id);

                Assert.True(result);
            }
        }

        [Fact]
        public void Exist_ReturnsFalse()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var reservationsService = new ReservationsService(dbContext);
                var result = reservationsService.Exists("fsfsfsf");

                Assert.False(result);
            }
        }

        [Fact]
        public void RemoveAsync_ReturnsTrue()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Reservation reservation = new Reservation()
                {
                    VehicleMake = "BMW",
                    VehicleModel = "M5",
                    LicenseNumber = "СА 1234 КР",
                    PhoneNumber = "0897482124",
                    ReservationDateTime = new DateTime(2020, 3, 21, 10, 30, 10),
                };

                var reservationsService = new ReservationsService(dbContext);

                dbContext.Reservations.Add(reservation);
                dbContext.SaveChanges();

                var result = reservationsService.RemoveAsync(reservation.Id);

                Assert.True(result.Result);
            }
        }

        [Fact]
        public void RemoveAsync_ReturnsFalse()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var reservationsService = new ReservationsService(dbContext);

                var result = reservationsService.RemoveAsync("ffsaf");

                Assert.False(result.Result);
            }
        }

        [Fact]
        public void EditAsync_ReturnsCorrectNumberOfModifiedEntries()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Reservation reservation = new Reservation()
                {
                    VehicleMake = "BMW",
                    VehicleModel = "M5",
                    LicenseNumber = "СА 1234 КР",
                    PhoneNumber = "0897482124",
                    ReservationDateTime = new DateTime(2020, 3, 21, 10, 30, 10),
                };

                var reservationsService = new ReservationsService(dbContext);

                dbContext.Reservations.Add(reservation);
                dbContext.SaveChanges();

                var result = reservationsService.EditAsync(reservation.Id);

                Assert.Equal(1, result.Result);
            }
        }

        [Fact]
        public void CountForUser_ReturnsCorrectUserReservations()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var user = new ApplicationUser { UserName = "ivan123", Email = "ivan@gmail.com" };
                Reservation reservation = new Reservation()
                {
                    VehicleMake = "BMW",
                    VehicleModel = "M5",
                    LicenseNumber = "СА 1234 КР",
                    PhoneNumber = "0897482124",
                    ReservationDateTime = new DateTime(2020, 3, 21, 10, 30, 10),
                    User = user,
                };

                var reservationsService = new ReservationsService(dbContext);

                dbContext.Reservations.Add(reservation);
                dbContext.SaveChanges();

                var result = reservationsService.CountForUser(user.UserName);

                Assert.Equal(1, result);
            }
        }

        [Fact]
        public void CreateAsync_ReturnsCorrectReservationId()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var user = new ApplicationUser { UserName = "ivan123", Email = "ivan@gmail.com" };
                dbContext.Users.Add(user);
                dbContext.SaveChanges();

                CreateReservationServiceModel reservation = new CreateReservationServiceModel
                {
                    VehicleMake = "BMW",
                    VehicleModel = "M5",
                    LicenseNumber = "СА 1234 КР",
                    PhoneNumber = "0897482124",
                    ReservationDateTime = new DateTime(2020, 3, 21, 10, 30, 10),
                    Username = user.UserName,
                };

                var reservationsService = new ReservationsService(dbContext);
                var result = reservationsService.CreateAsync(reservation);
                var reservationObj = dbContext.Reservations.FirstOrDefaultAsync();

                Assert.Equal(reservationObj.Result.Id, result.Result);
            }
        }
    }
}
