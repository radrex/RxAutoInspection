namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;
    using RxAuto.Data.Seeding.JSONSeed;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class EmployeesSeeder : ISeeder
    {
        //---------------- FIELDS -----------------
        private readonly List<JEmployee> employees;

        //------------- CONSTRUCTORS --------------
        public EmployeesSeeder(List<JEmployee> employees)
        {
            this.employees = employees;
        }

        //--------------- METHODS -----------------
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Employees.Any())
            {
                return;
            }

            foreach (JEmployee employee in this.employees)
            {
                await dbContext.Employees.AddAsync(new Employee
                {
                    FirstName = employee.FirstName,
                    MiddleName = employee.MiddleName,
                    LastName = employee.LastName,
                    PhoneNumber = employee.PhoneNumber,
                    Email = employee.Email,
                    Town = employee.Town,
                    Address = employee.Address,
                    ImageUrl = employee.ImageUrl,
                    JobPositionId = employee.JobPositionId,
                    OperatingLocationId = employee.OperatingLocationId,
                });
            }

            await dbContext.SaveChangesAsync(); 
        }
    }
}
