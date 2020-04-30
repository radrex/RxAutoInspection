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
    using RxAuto.Services.Models.Employees;

    public class EmployeeTests
    {
        [Fact]
        public void Count_ReturnsCorrectCount()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Employee employee = new Employee()
                {
                    FirstName = "Ivan",
                    MiddleName = "Ivanov",
                    LastName = "Ivanov",
                    PhoneNumber = "0897924218",
                    Email = "ivan@gmail.com",
                    Town = "Sofia",
                    Address = "address 1",
                };

                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();

                var employeesService = new EmployeesService(dbContext);
                int employeesCount = employeesService.Count();

                Assert.Equal(1, employeesCount);
            }
        }

        [Fact]
        public void GetById_ReturnsCorrectEmployee()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                JobPosition jobPosition = new JobPosition()
                {
                    Name = "newJobPos",
                };
                dbContext.JobPositions.Add(jobPosition);
                dbContext.SaveChanges();

                OperatingLocation operatingLocation = new OperatingLocation()
                {
                    Town = "Sofia",
                    Address = "test street",
                    ImageUrl = "kgkkkgk",
                };
                dbContext.OperatingLocations.Add(operatingLocation);
                dbContext.SaveChanges();

                Employee employee = new Employee()
                {
                    FirstName = "Ivan",
                    MiddleName = "Ivanov",
                    LastName = "Ivanov",
                    PhoneNumber = "0897924218",
                    Email = "ivan@gmail.com",
                    Town = "Sofia",
                    Address = "address 1",
                    ImageUrl = "aasdfag",
                    OperatingLocationId = operatingLocation.Id,
                    JobPositionId = jobPosition.Id,
                };

                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();

                var employeesService = new EmployeesService(dbContext);
                var result = employeesService.GetById(employee.Id);

                Assert.Equal("Ivan", result.FirstName);
            }
        }

        [Fact]
        public void Exist_ReturnsTrue()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                JobPosition jobPosition = new JobPosition()
                {
                    Name = "newJobPos",
                };
                dbContext.JobPositions.Add(jobPosition);
                dbContext.SaveChanges();

                OperatingLocation operatingLocation = new OperatingLocation()
                {
                    Town = "Sofia",
                    Address = "test street",
                    ImageUrl = "kgkkkgk",
                };
                dbContext.OperatingLocations.Add(operatingLocation);
                dbContext.SaveChanges();

                Employee employee = new Employee()
                {
                    FirstName = "Ivan",
                    MiddleName = "Ivanov",
                    LastName = "Ivanov",
                    PhoneNumber = "0897924218",
                    Email = "ivan@gmail.com",
                    Town = "Sofia",
                    Address = "address 1",
                    ImageUrl = "aasdfag",
                    OperatingLocationId = operatingLocation.Id,
                    JobPositionId = jobPosition.Id,
                };

                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();

                var employeesService = new EmployeesService(dbContext);
                var result = employeesService.Exists(employee.Id);

                Assert.True(result);
            }
        }

        [Fact]
        public void Exist_ReturnsFalse()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var employeesService = new EmployeesService(dbContext);
                var result = employeesService.Exists("asfalsfha");

                Assert.False(result);
            }
        }

        [Fact]
        public void RemoveAsync_ReturnsTrue()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                JobPosition jobPosition = new JobPosition()
                {
                    Name = "newJobPos",
                };
                dbContext.JobPositions.Add(jobPosition);
                dbContext.SaveChanges();

                OperatingLocation operatingLocation = new OperatingLocation()
                {
                    Town = "Sofia",
                    Address = "test street",
                    ImageUrl = "kgkkkgk",
                };
                dbContext.OperatingLocations.Add(operatingLocation);
                dbContext.SaveChanges();

                Employee employee = new Employee()
                {
                    FirstName = "Ivan",
                    MiddleName = "Ivanov",
                    LastName = "Ivanov",
                    PhoneNumber = "0897924218",
                    Email = "ivan@gmail.com",
                    Town = "Sofia",
                    Address = "address 1",
                    ImageUrl = "aasdfag",
                    OperatingLocationId = operatingLocation.Id,
                    JobPositionId = jobPosition.Id,
                };

                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();

                var employeesService = new EmployeesService(dbContext);
                var result = employeesService.RemoveAsync(employee.Id);

                Assert.True(result.Result);
            }
        }

        [Fact]
        public void RemoveAsync_ReturnsFalse()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var employeesService = new EmployeesService(dbContext);

                var result = employeesService.RemoveAsync("asgasg");

                Assert.False(result.Result);
            }
        }

        [Fact]
        public void CreateAsync_ReturnsCorrectEmployeeId()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                JobPosition jobPosition = new JobPosition()
                {
                    Name = "newJobPos",
                };
                dbContext.JobPositions.Add(jobPosition);
                dbContext.SaveChanges();

                OperatingLocation operatingLocation = new OperatingLocation()
                {
                    Town = "Sofia",
                    Address = "test street",
                    ImageUrl = "kgkkkgk",
                };
                dbContext.OperatingLocations.Add(operatingLocation);
                dbContext.SaveChanges();

                CreateEmployeeServiceModel employee = new CreateEmployeeServiceModel
                {
                    FirstName = "Ivan",
                    MiddleName = "Ivanov",
                    LastName = "Ivanov",
                    Phone = "0897924218",
                    Email = "ivan@gmail.com",
                    Town = "Sofia",
                    Address = "address 1",
                    ImageUrl = "aasdfag",
                    OperatingLocationId = operatingLocation.Id,
                    JobPositionId = jobPosition.Id,
                };

                var employeesService = new EmployeesService(dbContext);
                var result = employeesService.CreateAsync(employee);
                var employeeObj = dbContext.Employees.FirstOrDefaultAsync();

                Assert.Equal(employeeObj.Result.Id, result.Result);
            }
        }

        [Fact]
        public void EditAsync_ReturnsCorrectNumberOfModifiedEntries()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                JobPosition jobPosition = new JobPosition()
                {
                    Name = "newJobPos",
                };
                dbContext.JobPositions.Add(jobPosition);
                dbContext.SaveChanges();

                OperatingLocation operatingLocation = new OperatingLocation()
                {
                    Town = "Sofia",
                    Address = "test street",
                    ImageUrl = "kgkkkgk",
                };
                dbContext.OperatingLocations.Add(operatingLocation);
                dbContext.SaveChanges();

                Employee employee = new Employee()
                {
                    FirstName = "Ivan",
                    MiddleName = "Ivanov",
                    LastName = "Ivanov",
                    PhoneNumber = "0897924218",
                    Email = "ivan@gmail.com",
                    Town = "Sofia",
                    Address = "address 1",
                    ImageUrl = "aasdfag",
                    OperatingLocationId = operatingLocation.Id,
                    JobPositionId = jobPosition.Id,
                };

                var employeesService = new EmployeesService(dbContext);
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
                var employeeObj = dbContext.Employees.FirstOrDefaultAsync();

                EditEmployeeServiceModel model = new EditEmployeeServiceModel
                {
                    Id = employeeObj.Result.Id,
                    FirstName = "new name",
                };

                var result = employeesService.EditAsync(model);

                Assert.Equal(1, result.Result);
            }
        }

        [Fact]
        public void All_ReturnsCorrectCollection()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                JobPosition jobPosition = new JobPosition()
                {
                    Name = "newJobPos",
                };
                dbContext.JobPositions.Add(jobPosition);
                dbContext.SaveChanges();

                OperatingLocation operatingLocation = new OperatingLocation()
                {
                    Town = "Sofia",
                    Address = "test street",
                    ImageUrl = "kgkkkgk",
                };
                dbContext.OperatingLocations.Add(operatingLocation);
                dbContext.SaveChanges();

                Employee employee = new Employee()
                {
                    FirstName = "Ivan",
                    MiddleName = "Ivanov",
                    LastName = "Ivanov",
                    PhoneNumber = "0897924218",
                    Email = "ivan@gmail.com",
                    Town = "Sofia",
                    Address = "address 1",
                    ImageUrl = "aasdfag",
                    OperatingLocationId = operatingLocation.Id,
                    JobPositionId = jobPosition.Id,
                };
                
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();

                var employeesService = new EmployeesService(dbContext);
                var employees = employeesService.All();

                Assert.Collection(employees, item => Assert.Contains("Ivan", employee.FirstName));
            }                                
        }
    }
}
