namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;
    using RxAuto.Data.Seeding.JSONSeed;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class DepartmentsSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly List<JDepartment> departments;

        //------------- CONSTRUCTORS --------------
        public DepartmentsSeeder(List<JDepartment> departments)
        {
            this.departments = departments;
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Departments.Any())
            {
                return;
            }

            foreach (JDepartment department in this.departments)
            {
                await dbContext.Departments.AddAsync(new Department
                {
                    Name = department.Name,
                    Email = department.Email,
                    Description = department.Description,
                    OperatingLocationId = department.OperatingLocationId,
                });
                await dbContext.SaveChangesAsync(); // Do it on each step to preserve insertion order. :(

                foreach (int phoneId in department.PhoneIds)
                {
                    await dbContext.DepartmentPhones.AddAsync(new DepartmentPhone
                    {
                        DepartmentId = department.Id,
                        PhoneId = phoneId
                    });
                }
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
