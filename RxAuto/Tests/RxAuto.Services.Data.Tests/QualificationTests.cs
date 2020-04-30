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

    public class QualificationTests
    {
        [Fact]
        public void GetAll_ReturnsCorrectCount()
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
    }
}
