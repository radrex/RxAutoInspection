namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Seeds <c>departments</c> to <see cref="Department"/> entity in database using <see cref="ApplicationDbContext"/>.
    /// </summary>
    public class DepartmentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Departments.Any())
            {
                return;
            }

            var departments = new List<(string Name, string Email, List<int> Phones, int OperatingLocationId)>
            {
                ("Support", "blg_support@gmail.com", new List<int>(dbContext.Phones
                                                                            .Where(p => p.PhoneNumber == "0897571823" ||
                                                                                        p.PhoneNumber == "0898391232" ||
                                                                                        p.PhoneNumber == "0897931421")
                                                                            .Select(p => p.Id)
                                                                            .ToList()), 
                    dbContext.OperatingLocations.FirstOrDefault(ol => ol.Town == "Благоевград").Id
                ),
                ("Support", "blg_info@gmail.com", new List<int>(dbContext.Phones
                                                                         .Where(p => p.PhoneNumber == "0897571823" ||
                                                                                     p.PhoneNumber == "0897391431")
                                                                         .Select(p => p.Id)
                                                                         .ToList()),
                    dbContext.OperatingLocations.FirstOrDefault(ol => ol.Town == "Благоевград").Id
                ),
                ("Support", "sofia_info@gmail.com", new List<int>(dbContext.Phones
                                                                           .Where(p => p.PhoneNumber == "0898391953" ||
                                                                                       p.PhoneNumber == "0897572942")
                                                                           .Select(p => p.Id)
                                                                           .ToList()),
                    dbContext.OperatingLocations.FirstOrDefault(ol => ol.Town == "София").Id
                )
            };

            foreach (var department in departments)
            {
                Department departmentEntity = new Department 
                {
                    Name = department.Name,
                    Email = department.Email,
                    OperatingLocationId = department.OperatingLocationId,
                };

                foreach (int phoneId in department.Phones)
                {
                    await dbContext.DepartmentPhones.AddAsync(new DepartmentPhone
                    {
                        Department = departmentEntity,
                        PhoneId = phoneId,
                    });
                }
            }
        }
    }
}
