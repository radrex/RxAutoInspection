namespace RxAuto.Data.Seeding
{
    using RxAuto.Data.Models;
    using RxAuto.Data.Models.Enums;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Seeds <c>services</c> to <see cref="Service"/> entity in database using <see cref="ApplicationDbContext"/>.
    /// </summary>
    public class ServicesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Services.Any())
            {
                return;
            }

            var services = new List<(string Name, decimal Price, string ServiceTypeName, List<(string Town, string Address)> Locations, List<string> DocumentNames, List<VehicleCategory> VehicleCategories, bool IsShownInMenu)>
            {
                ("M1 - Лек автомобил", 35.0M, "ГТП", new List<(string Town, string Address)>
                                                     {
                                                         ("Благоевград", "ул. Патриарх Евтимий 23"),
                                                         ("София", "ул. Васил Левски 10"),
                                                     },
                                                     new List<string>
                                                     {
                                                         "Документ за самоличност на лицето представило ППС на преглед",
                                                         "Документ от съответния контролен орган за техническа изправност на монтирано съоръжение",
                                                         "Свидетелство за регистрация на ППС част II (Оригинал)",
                                                         "Свидетелство за регистрация на ППС част I (Може да бъде представено копие)",
                                                     },
                                                     new List<VehicleCategory>
                                                     {
                                                         VehicleCategory.M1,
                                                     },
                                                     true
                ),
                ("M2 - Автобус", 60.0M, "ГТП", new List<(string Town, string Address)>
                                               {
                                                   ("Благоевград", "ул. Патриарх Евтимий 23"),
                                                   ("София", "ул. Васил Левски 10"),
                                               },
                                               new List<string>
                                               {
                                                   "Документ за самоличност на лицето представило ППС на преглед",
                                                   "Документ от съответния контролен орган за техническа изправност на монтирано съоръжение",
                                                   "Свидетелство за регистрация на ППС част II (Оригинал)",
                                                   "Свидетелство за регистрация на ППС част I (Може да бъде представено копие)",
                                               },
                                               new List<VehicleCategory>
                                               {
                                                   VehicleCategory.M2,
                                               },
                                               true
                ),
                ("M3 - Автобус", 60.0M, "ГТП", new List<(string Town, string Address)>
                                               {
                                                   ("Благоевград", "ул. Патриарх Евтимий 23"),
                                                   ("София", "ул. Васил Левски 10"),
                                               },
                                               new List<string>
                                               {
                                                   "Документ за самоличност на лицето представило ППС на преглед",
                                                   "Документ от съответния контролен орган за техническа изправност на монтирано съоръжение",
                                                   "Свидетелство за регистрация на ППС част II (Оригинал)",
                                                   "Свидетелство за регистрация на ППС част I (Може да бъде представено копие)",
                                               },
                                               new List<VehicleCategory>
                                               {
                                                   VehicleCategory.M3,
                                               },
                                               true
                ),
                ("N1 - Товарен автомобил", 40.0M, "ГТП", new List<(string Town, string Address)>
                                                         {
                                                             ("Благоевград", "ул. Патриарх Евтимий 23"),
                                                         },
                                                         new List<string>
                                                         {
                                                             "Документ за самоличност на лицето представило ППС на преглед",
                                                             "Документ от съответния контролен орган за техническа изправност на монтирано съоръжение",
                                                             "Свидетелство за регистрация на ППС част II (Оригинал)",
                                                             "Свидетелство за регистрация на ППС част I (Може да бъде представено копие)",
                                                         },
                                                         new List<VehicleCategory>
                                                         {
                                                             VehicleCategory.N1,
                                                         },
                                                         true
                ),
                ("N2 - Товарен автомобил", 55.0M, "ГТП", new List<(string Town, string Address)>
                                                         {
                                                             ("Благоевград", "ул. Патриарх Евтимий 23"),
                                                         },
                                                         new List<string>
                                                         {
                                                             "Документ за самоличност на лицето представило ППС на преглед",
                                                             "Документ от съответния контролен орган за техническа изправност на монтирано съоръжение",
                                                             "Свидетелство за регистрация на ППС част II (Оригинал)",
                                                             "Свидетелство за регистрация на ППС част I (Може да бъде представено копие)",
                                                         },
                                                         new List<VehicleCategory>
                                                         {
                                                             VehicleCategory.N2,
                                                         },
                                                         true
                ),
            };

            foreach (var serviceInfo in services)
            {
                //---------------------------- Service ----------------------------
                ServiceType serviceType = dbContext.ServiceTypes.FirstOrDefault(st => st.Name == serviceInfo.ServiceTypeName);
                Service service = new Service
                {
                    Name = serviceInfo.Name,
                    Price = serviceInfo.Price,
                    ServiceType = serviceType,
                    IsShownInMenu = serviceInfo.IsShownInMenu,
                };
                await dbContext.Services.AddAsync(service);

                //---------------------------- Operating Locations ----------------------------
                List<OperatingLocation> locations = new List<OperatingLocation>();
                foreach (var location in serviceInfo.Locations)
                {
                    locations.Add(dbContext.OperatingLocations.FirstOrDefault(ol => ol.Town == location.Town && ol.Address == location.Address));
                }

                foreach (var operatingLocation in locations)
                {
                    await dbContext.ServiceOperatingLocations.AddAsync(new ServiceOperatingLocation
                    {
                        OperatingLocation = operatingLocation,
                        Service = service,
                    });
                }

                //---------------------------- Documents ----------------------------
                List<Document> documents = new List<Document>();
                foreach (var document in serviceInfo.DocumentNames)
                {
                    documents.Add(dbContext.Documents.FirstOrDefault(d => d.Name == document));
                }

                foreach (var document in documents)
                {
                    await dbContext.ServiceDocument.AddAsync(new ServiceDocument
                    {
                        Document = document,
                        Service = service,
                    });
                }

                //---------------------------- Vehicle Types ----------------------------
                List<VehicleType> vehicleTypes = new List<VehicleType>();
                foreach (var vehicleCategory in serviceInfo.VehicleCategories)
                {
                    vehicleTypes.Add(dbContext.VehicleTypes.FirstOrDefault(vt => vt.VehicleCategory == vehicleCategory));
                }

                foreach (var vehicleType in vehicleTypes)
                {
                    await dbContext.ServiceVehicleTypes.AddAsync(new ServiceVehicleType
                    {
                        VehicleType = vehicleType,
                        Service = service,
                    });
                }
            }
        }
    }
}
