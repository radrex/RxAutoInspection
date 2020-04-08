namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.Documents;
    using RxAuto.Services.Models.ServiceTypes;
    using RxAuto.Services.Models.VehicleTypes;
    using RxAuto.Services.Models.OperatingLocations;

    using RxAuto.Web.ViewModels.UnifiedModels;
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

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using RxAuto.Services.Models.Services;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class ServicesController : Controller
    {
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
