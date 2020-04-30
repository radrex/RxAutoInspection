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

    public class QualificationTests
    {
        [Fact]
        public void Count_ReturnsCorrectCount()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Qualification qualification = new Qualification() { Name = "TestQualification", Description = "random desc" };
                dbContext.Qualifications.Add(qualification);
                dbContext.SaveChanges();

                var qualificationsService = new QualificationsService(dbContext);
                int qualificationsCount = qualificationsService.Count();

                Assert.Equal(1, qualificationsCount);
            }
        }

        [Fact]
        public void GetAll_ReturnsCorrectCollection()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Qualification qualification1 = new Qualification() { Name = "TestQualification", Description = "random desc" };
                Qualification qualification2 = new Qualification() { Name = "TestQualification2", Description = "random desc2" };

                dbContext.Qualifications.Add(qualification1);
                dbContext.Qualifications.Add(qualification2);
                dbContext.SaveChanges();

                var qualificationsService = new QualificationsService(dbContext);
                var qualifications = qualificationsService.GetAll();

                Assert.Collection(qualifications, item => Assert.Contains("TestQualification", qualification1.Name),
                                                  item => Assert.Contains("TestQualification2", qualification2.Name));
            }
        }

        [Fact]
        public void GetById_ReturnsCorrectQualification()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Qualification qualification = new Qualification() { Name = "TestQualification", Description = "random desc" };

                dbContext.Qualifications.Add(qualification);
                dbContext.SaveChanges();

                var qualificationsService = new QualificationsService(dbContext);
                var result = qualificationsService.GetById(1);

                Assert.Equal("TestQualification", result.Name);
            }
        }

        [Fact]
        public void GetByName_ReturnsCorrectQualification()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Qualification qualification = new Qualification() { Name = "TestQualification", Description = "random desc" };

                dbContext.Qualifications.Add(qualification);
                dbContext.SaveChanges();

                var qualificationsService = new QualificationsService(dbContext);
                var result = qualificationsService.GetByName("TestQualification");

                Assert.Equal("TestQualification", result.Name);
            }
        }

        [Fact]
        public void Exist_ReturnsTrue()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Qualification qualification = new Qualification() { Name = "TestQualification", Description = "random desc" };

                dbContext.Qualifications.Add(qualification);
                dbContext.SaveChanges();

                var qualificationsService = new QualificationsService(dbContext);
                var result = qualificationsService.Exists(1);

                Assert.True(result);
            }
        }

        [Fact]
        public void Exist_ReturnsFalse()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var qualificationsService = new QualificationsService(dbContext);
                var result = qualificationsService.Exists(1);

                Assert.False(result);
            }
        }

        [Fact]
        public void All_ReturnsCorrectCollection()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Qualification qualification1 = new Qualification() { Name = "TestQualification", Description = "random desc" };
                Qualification qualification2 = new Qualification() { Name = "TestQualification2", Description = "random desc2" };

                dbContext.Qualifications.Add(qualification1);
                dbContext.Qualifications.Add(qualification2);
                dbContext.SaveChanges();

                var qualificationsService = new QualificationsService(dbContext);
                var qualifications = qualificationsService.All();

                Assert.Collection(qualifications, item => Assert.Contains("TestQualification", qualification1.Name),
                                                  item => Assert.Contains("TestQualification2", qualification2.Name));
            }
        }

        [Fact]
        public void RemoveAsync_ReturnsTrue()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Qualification qualification = new Qualification() { Name = "TestQualification", Description = "random desc" };
                var qualificationsService = new QualificationsService(dbContext);

                dbContext.Qualifications.Add(qualification);
                dbContext.SaveChanges();

                var result = qualificationsService.RemoveAsync(1);

                Assert.True(result.Result);
            }
        }

        [Fact]
        public void RemoveAsync_ReturnsFalse()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var qualificationsService = new QualificationsService(dbContext);

                var result = qualificationsService.RemoveAsync(1);

                Assert.False(result.Result);
            }
        }

        [Fact]
        public void CreateAsync_ReturnsCorrectQualificationId()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                CreateQualificationServiceModel qualification = new CreateQualificationServiceModel
                {
                    Name = "TestQualification",
                    Description = "random desc",
                };

                var qualificationsService = new QualificationsService(dbContext);
                var result = qualificationsService.CreateAsync(qualification);

                Assert.Equal(1, result.Result);
            }
        }

        [Fact]
        public void EditAsync_ReturnsCorrectNumberOfModifiedEntries()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                Qualification qualification = new Qualification() { Name = "TestQualification", Description = "random desc" };
                EditQualificationServiceModel model = new EditQualificationServiceModel
                {
                    Id = 1,
                    Name = "NewQualificationName",
                };
                var qualificationsService = new QualificationsService(dbContext);

                dbContext.Qualifications.Add(qualification);
                dbContext.SaveChanges();

                var result = qualificationsService.EditAsync(model);

                Assert.Equal(1, result.Result);
            }
        }

    }
}