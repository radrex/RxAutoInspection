namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Seeds <c>employees</c> to <see cref="Employee"/> entity in database using <see cref="ApplicationDbContext"/>.
    /// </summary>
    public class EmployeesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Employees.Any())
            {
                return;
            }

            var employees = new List<(string FirstName, string MiddleName, string LastName, 
                                      string PhoneNumber, string Email, string Town, string Address, string ImageUrl, 
                                      string JobPosition, string OperatingLocation)>
            {
                (
                    "Иван", "Петров", "Иванов", "0987384017", 
                    "ivan_petrov@gmail.com", "Благоевград", "ул. Джеймс Баучер 12", "https://i.dlpng.com/static/png/6402200_preview.png",
                    "Ръководител КТП", "Благоевград"
                ),
                (
                    "Георги", "Петров", "Георгиев", "0987382088",
                    "george5@gmail.com", "Благоевград", "ул. Христо Ботев 3", "https://i.dlpng.com/static/png/6402200_preview.png",
                    "Технически специалист", "Благоевград"
                ),
                (
                    "Стоян", "Георгиев", "Стоянов", "0987122038",
                    "stoyanov@gmail.com", "Перник", "ул. Васил Левски 9", "https://i.dlpng.com/static/png/6402200_preview.png",
                    "Технически специалист", "София"
                ),
            };

            foreach (var employee in employees)
            {
                JobPosition jobPosition = dbContext.JobPositions.FirstOrDefault(jp => jp.Name == employee.JobPosition);
                OperatingLocation operatingLocation = dbContext.OperatingLocations.FirstOrDefault(t => t.Town == employee.OperatingLocation);

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
                    JobPosition = jobPosition,
                    OperatingLocation = operatingLocation,
                });
            }
        }
    }
}
