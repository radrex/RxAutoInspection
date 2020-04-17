namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.Employees;

    using RxAuto.Web.ViewModels.Employees.ViewModels;
    using RxAuto.Web.ViewModels.Employees.InputModels;
    using RxAuto.Web.ViewModels.JobPositions.ViewModel;
    using RxAuto.Web.ViewModels.OperatingLocations.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class EmployeesController : Controller
    {
        //--------------- CONSTANTS ---------------
        private const int ItemsPerPage = 10;

        //---------------- FIELDS -----------------
        private readonly IEmployeesService employeesService;
        private readonly IJobPositionsService jobPositionsService;
        private readonly IOperatingLocationsService operatingLocationsService;
        private readonly EmployeeInputModel employeeInputModel;

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
        /// <param name="model">Input model for entering Employee information from the user.</param>
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
            return this.RedirectToAction("Create");
        }

        //------------------------- LISTING FOR EMPLOYEES ----------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Employees/All/{page}</para>
        /// <para>Returns a View with Employees listing using Pagination.</para>
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns>View with Employees listing</returns>
        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var viewModel = new EmployeesListingViewModel()
            {
                Employees = employeesService.All(ItemsPerPage, (page - 1) * ItemsPerPage).Select(x => new EmployeeViewModel
                {
                    Id = x.Id,
                    FullName = $"{x.FirstName} {x.MiddleName} {x.LastName}",
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    OperatingLocation = x.OperatingLocationTown + Environment.NewLine + x.OperatingLocationAddress,
                    JobPosition = x.JobPosition,
                }),
            };

            int count = this.employeesService.Count();
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        //------------------------- DETAILS OF AN EMPLOYEE ---------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Employees/Details/{id}</para>
        /// <para>Returns a View with details information for an <c>Employee</c>.</para>
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>Employee details View</returns>
        [HttpGet]
        public IActionResult Details(string id)
        {
            EmployeeServiceModel employee = this.employeesService.GetById(id);
            if (employee.FullName == null)
            {
                return this.BadRequest();
            }

            var model = new EmployeeDetailsViewModel
            {
                Id = employee.Id,
                FullName = employee.FullName,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                HomeAddress = employee.HomeAddress,
                ImageUrl = employee.ImageUrl,
                OperatingLocation = employee.OperatingLocation,
                // TODO: add opLoc img
                JobPosition = employee.JobPosition,
                // TODO: add job position qualifications table
            };

            return this.View(model);
        }

        //------------------------- EDIT AN EMPLOYEE ---------------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Employees/Edit/{id}</para>
        /// <para>Returns a View with edit information of an <c>Employee</c>.</para>
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>Employee edit View</returns>
        [HttpGet]
        public IActionResult Edit(string id)
        {
            EmployeeServiceModel employee = this.employeesService.GetById(id);
            if (employee.FullName == null)
            {
                return this.BadRequest();
            }

            var model = new EmployeeInputModel
            {
                JobPositionId = employee.JobPositionId,
                JobPositions = this.jobPositionsService.GetAll().Select(x => new JobPositionsDropdownViewModel
                {
                    Id = x.Id,
                    JobPositionName = x.Name,
                }),
                // TODO: add job positions qualifications table

                OperatingLocationId = employee.OperatingLocationId,
                OperatingLocations = this.operatingLocationsService.GetAll().Select(x => new OperatingLocationsDropdownViewModel
                {
                    Id = x.Id,
                    Town = x.Town,
                    Address = x.Address,
                }),
                // TODO: add opLoc img

                Id = employee.Id,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Phone = employee.PhoneNumber,
                Email = employee.Email,
                Town = employee.Town,
                Address = employee.Address,
                ImageUrl = employee.ImageUrl,
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Employees/Edit/{id}</para>
        /// <para>Edits an <c>Employee</c>.</para>
        /// </summary>
        /// <param name="model">Input model for editing an Employee</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeInputModel model)
        {
            if (!this.employeesService.Exists(model.Id))
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            EditEmployeeServiceModel serviceModel = new EditEmployeeServiceModel
            {
                Id = model.Id,
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

            await this.employeesService.EditAsync(serviceModel);
            return this.RedirectToAction("Details", "Employees", new { id = serviceModel.Id });
        }

        //------------------------- DELETION OF AN EMPLOYEE --------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Employees/Delete/{id}</para>
        /// <para>Returns a View with delete confirmation information for an <c>Employee</c>.</para>
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>Delete employee confirmation View</returns>
        [HttpGet]
        public IActionResult Delete(string id)
        {
            EmployeeServiceModel employee = this.employeesService.GetById(id);
            if (employee.FullName == null)
            {
                return this.BadRequest();
            }

            var model = new DeleteEmployeeViewModel
            {
                Id = employee.Id,
                FullName = employee.FullName,
                OperatingLocation = employee.OperatingLocation,
                JobPosition = employee.JobPosition,
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Employees/Delete/{id}</para>
        /// <para>Deletes the selected employee.</para>
        /// </summary>
        /// <param name="model">View model for deletion of an Employee</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteEmployeeViewModel model)
        {
            var success = await this.employeesService.RemoveAsync(model.Id);
            if (!success)
            {
                return this.RedirectToAction("Error", "Home"); // TODO: redirect
            }

            return this.RedirectToAction("All", "Employees");
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           PRIVATE METHODS                                           //
        //-----------------------------------------------------------------------------------------------------//
        private void FillEmployeeInputModel()
        {
            var jobPositions = this.jobPositionsService.GetAll().Select(x => new JobPositionsDropdownViewModel
            {
                Id = x.Id,
                JobPositionName = x.Name,
            });

            var operatingLocations = this.operatingLocationsService.GetAll().Select(x => new OperatingLocationsDropdownViewModel
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
