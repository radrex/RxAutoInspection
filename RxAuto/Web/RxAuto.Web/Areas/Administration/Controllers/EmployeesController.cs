namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.Employees;
    using RxAuto.Web.ViewModels.Employees.InputModels;
    using RxAuto.Web.ViewModels.JobPositions.ViewModel;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System.Linq;
    using System.Threading.Tasks;
    using RxAuto.Web.ViewModels.OperatingLocations.ViewModels;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class EmployeesController : Controller
    {
        //---------------- FIELDS -----------------
        private readonly IEmployeesService employeesService;
        private readonly IJobPositionsService jobPositionsService;
        private readonly IOperatingLocationsService operatingLocationsService;
        private EmployeeInputModel employeeInputModel;

        //------------- CONSTRUCTORS --------------
        public EmployeesController(IEmployeesService employeesService, IJobPositionsService jobPositionsService, IOperatingLocationsService operatingLocationsService)
        {
            this.employeesService = employeesService;
            this.jobPositionsService = jobPositionsService;
            this.operatingLocationsService = operatingLocationsService;

            this.employeeInputModel = new EmployeeInputModel();
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        //------------------------- CREATE EMPLOYEE VIEW FORM ------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Employees/Create/</para>
        /// <para>Initializes a <see cref="EmployeeInputModel"/> containing Employee credential properties.</para>
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public IActionResult Create()
        {
            this.FillEmployeeInputModel();
            return this.View(this.employeeInputModel);
        }

        //------------------------- CREATE FOR EMPLOYEE FORM -------------------------
        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Employees/Create/</para>
        /// <para>Initializes a <see cref="EmployeeInputModel"/> containing Employee credential properties.</para>
        /// <para>On this action we get <see cref="EmployeeInputModel"/>, we use it's data to create and add a new <c>Employee</c> to the database.</para>
        /// </summary>
        /// <param name="model">EmployeeInputModel</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeInputModel model)
        {
            this.FillEmployeeInputModel();
            if (!this.ModelState.IsValid)
            {
                return this.View("Create", this.employeeInputModel);
            }

            var employee = new CreateEmployeeServiceModel
            {
                JobPositionId = model.JobPositionId,
                OperatingLocationId = model.OperatingLocationId,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Phone = model.Phone,
                Email = model.Email,
                Town = model.Town,
                Address = model.Address,
                ImageUrl = model.ImageUrl,
            };

            await this.employeesService.CreateAsync(employee);
            return this.RedirectToAction("Create"); // return this.View check
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           PRIVATE METHODS                                           //
        //-----------------------------------------------------------------------------------------------------//
        private void FillEmployeeInputModel()
        {
            var jobPositions = this.jobPositionsService.GetAll().Select(x => new JobPositionsListingViewModel
            {
                Id = x.Id,
                JobPositionName = x.Name,
            });

            var operatingLocations = this.operatingLocationsService.GetAll().Select(x => new OperatingLocationsListingViewModel
            {
                Id = x.Id,
                Town = x.Town,
                Address = x.Address,
            });

            this.employeeInputModel.JobPositions = jobPositions;
            this.employeeInputModel.OperatingLocations = operatingLocations;
        }
    }
}
