namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.Services;
    using RxAuto.Services.Models.Documents;
    using RxAuto.Services.Models.ServiceTypes;
    using RxAuto.Services.Models.VehicleTypes;
    using RxAuto.Services.Models.OperatingLocations;

    using RxAuto.Web.ViewModels.UnifiedModels;
    using RxAuto.Web.ViewModels.Services.ViewModels;
    using RxAuto.Web.ViewModels.Documents.ViewModels;
    using RxAuto.Web.ViewModels.Services.InputModels;
    using RxAuto.Web.ViewModels.Documents.InputModels;
    using RxAuto.Web.ViewModels.ServiceTypes.ViewModels;
    using RxAuto.Web.ViewModels.VehicleTypes.ViewModels;
    using RxAuto.Web.ViewModels.ServiceTypes.InputModels;
    using RxAuto.Web.ViewModels.VehicleTypes.InputModels;
    using RxAuto.Web.ViewModels.OperatingLocations.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using RxAuto.Data.Models;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class ServicesController : Controller
    {
        //--------------- CONSTANTS ---------------
        private const int ItemsPerPage = 10;

        //---------------- FIELDS -----------------
        private readonly IServicesService servicesService;
        private readonly IDocumentsService documentsService;
        private readonly IServiceTypesService serviceTypesService;
        private readonly IOperatingLocationsService operatingLocationsService;
        private readonly IVehicleTypesService vehicleTypesService;
        private readonly ServicesUnifiedModel unifiedModel;

        //------------- CONSTRUCTORS --------------
        public ServicesController(IServicesService servicesService, 
                                  IServiceTypesService serviceTypesService,
                                  IOperatingLocationsService operatingLocationsService,
                                  IDocumentsService documentsService,
                                  IVehicleTypesService vehicleTypesService)
        {
            this.servicesService = servicesService;
            this.serviceTypesService = serviceTypesService;
            this.operatingLocationsService = operatingLocationsService;
            this.documentsService = documentsService;
            this.vehicleTypesService = vehicleTypesService;
            this.unifiedModel = new ServicesUnifiedModel
            {
                ServiceInputModel = new ServiceInputModel(),
                ServiceTypeInputModel = new ServiceTypeInputModel(),
                DocumentInputModel = new DocumentInputModel(),
                VehicleTypeInputModel = new VehicleTypeInputModel()
            };
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        //------------------------- CREATE SERVICE VIEW FORM ------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Services/Create/</para>
        /// <para>Initializes a <see cref="ServicesUnifiedModel"/> representing a collection of <see cref="ServiceInputModel"/>, <see cref="ServiceTypeInputModel"/>, <see cref="DocumentInputModel"/> and <see cref="VehicleTypeInputModel"/> and passes it to the View.</para>
        /// <para>The View renders 4 Partial Views. The 1st gets <see cref="ServicesUnifiedModel"/>, the 2nd <see cref="ServiceInputModel"/>, the 3rd <see cref="DocumentInputModel"/> and the 4th <see cref="VehicleTypeInputModel"/>.</para>
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public IActionResult Create()
        {
            this.FillServiceUnifiedModel();
            return this.View(this.unifiedModel);
        }

        //------------------------- CREATE FOR SERVICE FORM -------------------------
        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Services/Create/</para>
        /// <para>Initializes a <see cref="ServicesUnifiedModel"/> representing a collection of <see cref="ServiceInputModel"/>, <see cref="ServiceTypeInputModel"/>, <see cref="DocumentInputModel"/> and <see cref="VehicleTypeInputModel"/> and passes it to the View.</para>
        /// <para>The View renders 4 Partial Views. The 1st gets <see cref="ServicesUnifiedModel"/>, the 2nd <see cref="ServiceInputModel"/>, the 3rd <see cref="DocumentInputModel"/> and the 4th <see cref="VehicleTypeInputModel"/>.</para>
        /// <para>On this action we get <see cref="ServiceInputModel"/>, we use it's data to create and add a new <c>Service</c> to the database.</para>
        /// </summary>
        /// <param name="model">Input model for entering Service information from the user.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(ServiceInputModel model)
        {
            this.FillServiceUnifiedModel();
            if (!this.ModelState.IsValid)
            {
                return this.View("Create", this.unifiedModel);
            }

            var operatingLocations = new List<OperatingLocationsDropdownServiceModel>();
            if (model.OperatingLocationIds != null)
            {
                foreach (int operatingLocationId in model.OperatingLocationIds)
                {
                    operatingLocations.Add(new OperatingLocationsDropdownServiceModel
                    {
                        Id = operatingLocationId,
                    });
                }
            }

            var documents = new List<DocumentsDropdownServiceModel>();
            if (model.DocumentIds != null)
            {
                foreach (int documentId in model.DocumentIds)
                {
                    documents.Add(new DocumentsDropdownServiceModel
                    {
                        Id = documentId,
                    });
                }
            }

            var service = new CreateServiceServiceModel
            {
                ServiceTypeId = model.ServiceTypeId,
                VehicleTypeId = model.VehicleTypeId,
                ServiceName = model.ServiceName,
                ServiceDescription = model.ServiceDescription,
                IsShownInSubMenu = model.IsShownInSubMenu,
                Price = model.Price,
                OperatingLocations = operatingLocations,
                Documents = documents,
            };

            await this.servicesService.CreateAsync(service);
            return this.RedirectToAction("Create");
        }

        //------------------------- CREATE FOR SERVICE TYPE FORM --------------------
        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Services/Create/</para>
        /// <para>Initializes a <see cref="ServicesUnifiedModel"/> representing a collection of <see cref="ServiceInputModel"/>, <see cref="ServiceTypeInputModel"/>, <see cref="DocumentInputModel"/> and <see cref="VehicleTypeInputModel"/> and passes it to the View.</para>
        /// <para>The View renders 4 Partial Views. The 1st gets <see cref="ServicesUnifiedModel"/>, the 2nd <see cref="ServiceInputModel"/>, the 3rd <see cref="DocumentInputModel"/> and the 4th <see cref="VehicleTypeInputModel"/>.</para>
        /// <para>On this action we get <see cref="ServiceTypeInputModel"/>, we use it's data to create and add a new <c>ServiceType</c> to the database.</para>
        /// </summary>
        /// <param name="model">Input model for entering ServiceType information from the user.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateServiceType(ServiceTypeInputModel model)
        {
            this.FillServiceUnifiedModel();
            if (!this.ModelState.IsValid)
            {
                return this.View("Create", this.unifiedModel);
            }

            var serviceType = new CreateServiceTypeServiceModel
            {
                Name = model.ServiceTypeName,
                Description = model.ServiceTypeDescription,
                IsInDevelopment = model.IsShownInMainMenu,
            };

            await this.serviceTypesService.CreateAsync(serviceType);
            return this.RedirectToAction("Create", this.unifiedModel);
        }

        //------------------------- CREATE FOR VEHICLE TYPE FORM --------------------
        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Services/Create/</para>
        /// <para>Initializes a <see cref="ServicesUnifiedModel"/> representing a collection of <see cref="ServiceInputModel"/>, <see cref="ServiceTypeInputModel"/>, <see cref="DocumentInputModel"/> and <see cref="VehicleTypeInputModel"/> and passes it to the View.</para>
        /// <para>The View renders 4 Partial Views. The 1st gets <see cref="ServicesUnifiedModel"/>, the 2nd <see cref="ServiceInputModel"/>, the 3rd <see cref="DocumentInputModel"/> and the 4th <see cref="VehicleTypeInputModel"/>.</para>
        /// <para>On this action we get <see cref="VehicleTypeInputModel"/>, we use it's data to create and add a new <c>VehicleType</c> to the database.</para>
        /// </summary>
        /// <param name="model">Input model for entering VehicleType information from the user.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateVehicleType(VehicleTypeInputModel model)
        {
            this.FillServiceUnifiedModel();
            if (!this.ModelState.IsValid)
            {
                return this.View("Create", this.unifiedModel);
            }

            var vehicleType = new CreateVehicleTypeServiceModel
            {
                Name = model.VehicleTypeName,
                VehicleCategoryId = model.VehicleCategoryId,
                Description = model.VehicleTypeDescription,
            };

            await this.vehicleTypesService.CreateAsync(vehicleType);
            return this.RedirectToAction("Create");
        }

        //------------------------- CREATE FOR DOCUMENT FORM ------------------------
        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Services/Create/</para>
        /// <para>Initializes a <see cref="ServicesUnifiedModel"/> representing a collection of <see cref="ServiceInputModel"/>, <see cref="ServiceTypeInputModel"/>, <see cref="DocumentInputModel"/> and <see cref="VehicleTypeInputModel"/> and passes it to the View.</para>
        /// <para>The View renders 4 Partial Views. The 1st gets <see cref="ServicesUnifiedModel"/>, the 2nd <see cref="ServiceInputModel"/>, the 3rd <see cref="DocumentInputModel"/> and the 4th <see cref="VehicleTypeInputModel"/>.</para>
        /// <para>On this action we get <see cref="DocumentInputModel"/>, we use it's data to create and add a new <c>Document</c> to the database.</para>
        /// </summary>
        /// <param name="model">Input model for entering Document information from the user.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateDocument(DocumentInputModel model)
        {
            this.FillServiceUnifiedModel();
            if (!this.ModelState.IsValid)
            {
                return this.View("Create", this.unifiedModel);
            }

            var document = new CreateDocumentServiceModel
            {
                Name = model.DocumentName,
                Description = model.DocumentDescription,
            };

            await this.documentsService.CreateAsync(document);
            return this.RedirectToAction("Create");
        }

        //------------------------- LISTING FOR SERVICES ----------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Services/All/{page}</para>
        /// <para>Returns a View with Services listing using Pagination.</para>
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns>View with Services listing</returns>
        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var viewModel = new ServicesListingViewModel()
            {
                Services = this.servicesService.All(ItemsPerPage, (page - 1) * ItemsPerPage).Select(x => new ServiceViewModel 
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsShownInSubMenu = x.IsShownInSubMenu,
                    ServiceType = x.ServiceType,
                    VehicleType = x.VehicleType,
                    Price = x.Price,
                }),
            };

            int count = this.servicesService.Count();
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;
            return this.View(viewModel);
        }

        //------------------------- DETAILS OF A SERVICE ----------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Services/Details/{id}</para>
        /// <para>Returns a View with details information for a <c>Service</c>.</para>
        /// </summary>
        /// <param name="id">Service ID</param>
        /// <returns>Service details View</returns>
        [HttpGet]
        public IActionResult Details(int id)
        {
            ServiceServiceModel service = this.servicesService.GetById(id);
            if (service.Name == null)
            {
                return this.BadRequest();
            }

            var model = new ServiceDetailsViewModel
            {
                Id = service.Id,
                Name = service.Name,
                IsShownInSubMenu = service.IsShownInSubMenu == true ? "IsShownInSubMenu" : "IsNotShownInSubMenu",
                ServiceType = service.ServiceType,
                VehicleType = service.VehicleType,
                Description = service.Description,
                Price = service.Price,
                //TODO: Add operatingLocations, documents, reservations
            };

            return this.View(model);
        }

        //------------------------- EDIT A SERVICE ----------------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Services/Edit/{id}</para>
        /// <para>Returns a View with edit information of a <c>Service</c>.</para>
        /// </summary>
        /// <param name="id">Service ID</param>
        /// <returns>Service edit View</returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ServiceServiceModel service = this.servicesService.GetById(id);
            if (service.Name == null)
            {
                return this.BadRequest();
            }

            var model = new ServiceInputModel
            {
                Id = service.Id,
                ServiceName = service.Name,
                IsShownInSubMenu = service.IsShownInSubMenu,
                ServiceDescription = service.Description,
                Price = service.Price,

                VehicleTypeId = service.VehicleTypeId,
                VehicleTypes = this.vehicleTypesService.GetAll().Select(x => new VehicleTypesDropdownViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category,
                }),

                ServiceTypeId = service.ServiceTypeId,
                ServiceTypes = this.serviceTypesService.GetAll().Select(x => new ServiceTypesDropdownViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }),

                OperatingLocationIds = service.OperatingLocationIds,
                OperatingLocations = this.operatingLocationsService.GetAll().Select(x => new OperatingLocationsDropdownViewModel 
                {
                    Id = x.Id,
                    Town = x.Town,
                    Address = x.Address,
                }),

                DocumentIds = service.DocumentIds,
                Documents = this.documentsService.GetAll().Select(x => new DocumentsDropdownViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }),
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Services/Edit/{id}</para>
        /// <para>Edits a <c>Service</c>.</para>
        /// </summary>
        /// <param name="model">Input model for editing a Service</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(ServiceInputModel model)
        {
            if (!this.servicesService.Exists(model.Id))
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            EditServiceServiceModel serviceModel = new EditServiceServiceModel
            {
                Id = model.Id,
                Name = model.ServiceName,
                Price = model.Price,
                Description = model.ServiceDescription,
                IsShownInSubMenu = model.IsShownInSubMenu,

                ServiceTypeId = model.ServiceTypeId,
                VehicleTypeId = model.VehicleTypeId,

                OperatingLocationIds = (model.OperatingLocationIds == null) ? new int[0] : model.OperatingLocationIds,
                DocumentIds = (model.DocumentIds == null) ? new int[0] : model.DocumentIds,
            };

            await this.servicesService.EditAsync(serviceModel);
            return this.RedirectToAction("Details", "Services", new { id = serviceModel.Id });
        }

        //------------------------- DELETION OF A SERVICE ---------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Services/Delete/{id}</para>
        /// <para>Returns a View with delete confirmation information for a <c>Service</c>.</para>
        /// </summary>
        /// <param name="id">Service ID</param>
        /// <returns>Delete Service confirmation View</returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ServiceServiceModel service = this.servicesService.GetById(id);
            if (service.Name == null)
            {
                return this.BadRequest();
            }

            var model = new DeleteServiceViewModel
            {
                Id = service.Id,
                Name = service.Name,
                Price = service.Price,
                Description = service.Description,
                ServiceType = service.ServiceType,
                VehicleType = service.VehicleType,
                IsShownInSubMenu = (service.IsShownInSubMenu == true) ? "IsShownInSubMenu" : "NotShownInSubMenu",
                //TODO: add operating locations and documents tables
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Services/Delete/{id}</para>
        /// <para>Deletes the selected Service.</para>
        /// </summary>
        /// <param name="model"> View model for deletion of a Service</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteServiceViewModel model)
        {
            var success = await this.servicesService.RemoveAsync(model.Id);
            if (!success)
            {
                return this.RedirectToAction("Error", "Home"); // TODO: redirect
            }

            return this.RedirectToAction("All", "Services");
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           PRIVATE METHODS                                           //
        //-----------------------------------------------------------------------------------------------------//
        private void FillServiceUnifiedModel()
        {
            var serviceTypes = this.serviceTypesService.GetAll().Select(x => new ServiceTypesDropdownViewModel
            {
                Id = x.Id,
                Name = x.Name,
            });
            this.unifiedModel.ServiceInputModel.ServiceTypes = serviceTypes;

            var operatingLocations = this.operatingLocationsService.GetAll().Select(x => new OperatingLocationsDropdownViewModel
            {
                Id = x.Id,
                Town = x.Town,
                Address = x.Address,
            });
            this.unifiedModel.ServiceInputModel.OperatingLocations = operatingLocations;

            var vehicleTypes = this.vehicleTypesService.GetAll().Select(x => new VehicleTypesDropdownViewModel
            {
                Id = x.Id,
                Category = x.Category,
                Name = x.Name,
            });
            this.unifiedModel.ServiceInputModel.VehicleTypes = vehicleTypes;

            var documents = this.documentsService.GetAll().Select(x => new DocumentsDropdownViewModel
            {
                Id = x.Id,
                Name = x.Name,
            });
            this.unifiedModel.ServiceInputModel.Documents = documents;
        }
    }
}
