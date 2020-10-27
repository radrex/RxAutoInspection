namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class DepartmentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Departments.Any())
            {
                return;
            }

            var departments = new List<(string Name, string Email, List<Phone> Phones)>
            {
                ("Support", "blg_support@gmail.com", new List<Phone>(dbContext.Phones
                                                                            .Where(p => p.PhoneNumber == "0897571823" ||
                                                                                        p.PhoneNumber == "0898391232" ||
                                                                                        p.PhoneNumber == "0897931421")
                                                                            .ToList())
                ),
                ("Information", "blg_info@gmail.com", new List<Phone>(dbContext.Phones
                                                                             .Where(p => p.PhoneNumber == "0897571823" ||
                                                                                         p.PhoneNumber == "0897391431")
                                                                             .ToList())
                ),
                ("Information", "sofia_info@gmail.com", new List<Phone>(dbContext.Phones
                                                                               .Where(p => p.PhoneNumber == "0898391953" ||
                                                                                           p.PhoneNumber == "0897572942")
                                                                               .ToList())
                )
            };

            foreach (var department in departments)
            {
                Department departmentEntity = new Department
                {
                    Name = department.Name,
                    Email = department.Email,
                };

                foreach (var phone in department.Phones)
                {
                    await dbContext.DepartmentPhones.AddAsync(new DepartmentPhone
                    {
                        Department = departmentEntity,
                        Phone = phone,
                    });
                }
            }
        }
    }
}
