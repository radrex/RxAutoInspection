namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.OperatingLocations;

    using RxAuto.Web.ViewModels.Phones.ViewModels;
    using RxAuto.Web.ViewModels.Departments.ViewModels;
    using RxAuto.Web.ViewModels.OperatingLocations.InputModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System.Linq;
    using System.Threading.Tasks;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class OperatingLocationsController : Controller
    {
        //---------------- FIELDS -----------------
        private readonly IDepartmentsService departmentsService;
        private readonly IOperatingLocationsService operatingLocationsService;
        private readonly OperatingLocationInputModel operatingLocationInputModel;

        //------------- CONSTRUCTORS --------------
        public OperatingLocationsController(IDepartmentsService departmentsService, IOperatingLocationsService operatingLocationsService)
        {
            this.departmentsService = departmentsService;
            this.operatingLocationsService = operatingLocationsService;
            this.operatingLocationInputModel = new OperatingLocationInputModel();
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        //----------------------- CREATE OPERATING LOCATION VIEW FORM -----------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/OperatingLocations/Create/</para>
        /// <para>Initializes a <see cref="OperatingLocationInputModel"/> containing OperatingLocationg information properties.</para>
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public IActionResult Create()
        {
            this.FillOperatingLocationInputModel();
            return this.View(this.operatingLocationInputModel);
        }

        //----------------------- CREATE FOR OPERATING LOCATION FORM -----------------------
        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/OperatingLocations/Create/</para>
        /// <para>Initializes a <see cref="OperatingLocationInputModel"/> containing OperatingLocation information and collections of Departments.</para>
        /// <para>On this action we get <see cref="OperatingLocationInputModel"/>, we use it's data to create and add a new <c>OperatingLocation</c> to the database and to set selected internal phones to public.</para>
        /// </summary>
        /// <param name="model">Input model for entering OperatingLocation information from the user.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(OperatingLocationInputModel model)
        {
            this.FillOperatingLocationInputModel();
            if (!this.ModelState.IsValid)
            {
                return this.View("Create", this.operatingLocationInputModel);
            }

            var departments = this.departmentsService.GetAllDepartmentsWithSelectedPhones(model.DepartmentIds);
            var operatingLocation = new CreateOperatingLocationServiceModel
            {
                Town = model.Town,
                Address = model.Address,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Departments = departments,
            };

            await this.operatingLocationsService.CreateAsync(operatingLocation);
            return this.RedirectToAction("Create");
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           PRIVATE METHODS                                           //
        //-----------------------------------------------------------------------------------------------------//
        private void FillOperatingLocationInputModel()
        {
            var departments = this.departmentsService.GetAllWithoutOperatingLocation().Select(x => new DepartmentsDropdownViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Phones = x.Phones.Select(x => new PhonesDropdownViewModel
                {
                    Id = x.Id,
                    PhoneNumber = x.PhoneNumber,
                })
            });

            this.operatingLocationInputModel.Departments = departments;
        }
    }
}
