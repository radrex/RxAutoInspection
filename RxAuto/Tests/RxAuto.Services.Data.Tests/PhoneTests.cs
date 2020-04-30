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
    using RxAuto.Services.Models.Phones;

    public class PhoneTests
    {
        [Fact]
        public void Count_ReturnsCorrectCount()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Phone phone = new Phone() { PhoneNumber = "0897248721", IsInternal = true };
                dbContext.Phones.Add(phone);
                dbContext.SaveChanges();

                var phonesService = new PhonesService(dbContext);
                int qualificationsCount = phonesService.Count();

                Assert.Equal(1, qualificationsCount);
            }
        }

        [Fact]
        public void GetAll_ReturnsCorrectCollection()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Phone phone1 = new Phone() { PhoneNumber = "0897248721" };
                Phone phone2 = new Phone() { PhoneNumber = "0897248722" };

                dbContext.Phones.Add(phone1);
                dbContext.Phones.Add(phone2);
                dbContext.SaveChanges();

                var phonesService = new PhonesService(dbContext);
                var phones = phonesService.GetAll();

                Assert.Collection(phones, item => Assert.Contains("0897248721", phone1.PhoneNumber),
                                          item => Assert.Contains("0897248722", phone2.PhoneNumber));
            }
        }

        [Fact]
        public void All_ReturnsCorrectCollection()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Phone phone1 = new Phone() { PhoneNumber = "0897248721" };
                Phone phone2 = new Phone() { PhoneNumber = "0897248722" };

                dbContext.Phones.Add(phone1);
                dbContext.Phones.Add(phone2);
                dbContext.SaveChanges();

                var phonesService = new PhonesService(dbContext);
                var phones = phonesService.All();

                Assert.Collection(phones, item => Assert.Contains("0897248721", phone1.PhoneNumber),
                                          item => Assert.Contains("0897248722", phone2.PhoneNumber));
            }
        }

        [Fact]
        public void GetById_ReturnsCorrectPhone()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Phone phone = new Phone() { PhoneNumber = "0897248721" };

                dbContext.Phones.Add(phone);
                dbContext.SaveChanges();

                var phonesService = new PhonesService(dbContext);
                var result = phonesService.GetById(1);

                Assert.Equal("0897248721", result.PhoneNumber);
            }
        }

        [Fact]
        public void Exists_ReturnsTrue()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Phone phone = new Phone() { PhoneNumber = "0897248721" };

                dbContext.Phones.Add(phone);
                dbContext.SaveChanges();

                var phonesService = new PhonesService(dbContext);
                var result = phonesService.Exists(1);

                Assert.True(result);
            }
        }

        [Fact]
        public void Exists_ReturnsFalse()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var phonesService = new PhonesService(dbContext);
                var result = phonesService.Exists(1);

                Assert.False(result);
            }
        }

        [Fact]
        public void RemoveAsync_ReturnsTrue()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Phone phone = new Phone() { PhoneNumber = "0897248721" };
                var phonesService = new PhonesService(dbContext);

                dbContext.Phones.Add(phone);
                dbContext.SaveChanges();

                var result = phonesService.RemoveAsync(1);

                Assert.True(result.Result);
            }
        }

        [Fact]
        public void RemoveAsync_ReturnsFalse()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var phonesService = new PhonesService(dbContext);

                var result = phonesService.RemoveAsync(1);

                Assert.False(result.Result);
            }
        }

        [Fact]
        public void CreateAsync_ReturnsCorrectPhoneId()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                CreatePhoneServiceModel phone = new CreatePhoneServiceModel
                {
                    PhoneNumber = "0897248721",
                };

                var phonesService = new PhonesService(dbContext);
                var result = phonesService.CreateAsync(phone);

                Assert.Equal(1, result.Result);
            }
        }

        [Fact]
        public void EditAsync_ReturnsCorrectNumberOfModifiedEntries()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Phone phone = new Phone() { PhoneNumber = "0897248721" };
                EditPhoneServiceModel model = new EditPhoneServiceModel
                {
                    Id = 1,
                    PhoneNumber = "0897248722",
                };
                var phonesService = new PhonesService(dbContext);

                dbContext.Phones.Add(phone);
                dbContext.SaveChanges();

                var result = phonesService.EditAsync(model);

                Assert.Equal(1, result.Result);
            }
        }

        [Fact]
        public void IsPhoneContainedInOtherDepartments_ReturnsFalse()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            
            using (var dbContext = new ApplicationDbContext(options))
            {
                Phone phone = new Phone() { PhoneNumber = "0897248721", };
                var phonesService = new PhonesService(dbContext);

                dbContext.Phones.Add(phone);
                dbContext.SaveChanges();

                var result = phonesService.IsPhoneContainedInOtherDepartments(phone.PhoneNumber);

                Assert.False(result);
            }
        }

        [Fact]
        public void IsPhoneContainedInOtherDepartments_ReturnsTrue()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Department department = new Department() { Name = "test", Email = "test@gmail.com" };
                Department department2 = new Department() { Name = "test", Email = "test@gmail.com" };
                dbContext.Departments.Add(department);
                dbContext.Departments.Add(department2);

                DepartmentPhone departmentPhone = new DepartmentPhone() { DepartmentId = 1, PhoneId = 1 };
                DepartmentPhone departmentPhone2 = new DepartmentPhone() { DepartmentId = 2, PhoneId = 1 };
                dbContext.DepartmentPhones.Add(departmentPhone);
                dbContext.DepartmentPhones.Add(departmentPhone2);

                Phone phone = new Phone() { PhoneNumber = "0897248721" };
                phone.Departments.Add(departmentPhone);
                phone.Departments.Add(departmentPhone2);

                var phonesService = new PhonesService(dbContext);

                dbContext.Phones.Add(phone);
                dbContext.SaveChanges();

                var result = phonesService.IsPhoneContainedInOtherDepartments(phone.PhoneNumber);

                Assert.True(result);
            }
        }
    }
}
