namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.OperatingLocations;

    using RxAuto.Web.ViewModels.Phones.ViewModels;
    using RxAuto.Web.ViewModels.Departments.ViewModels;
    using RxAuto.Web.ViewModels.OperatingLocations.ViewModels;
    using RxAuto.Web.ViewModels.OperatingLocations.InputModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class OperatingLocationsController : Controller
    {
        //--------------- CONSTANTS ---------------
        private const int ItemsPerPage = 10;

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

        //----------------------- LISTING FOR OPERATING LOCATIONS --------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/OperatingLocations/All/{page}</para>
        /// <para>Returns a View with OperatingLocations listing using Pagination.</para>
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns>View with OperatingLocations listing</returns>
        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var viewModel = new OperatingLocationsListingViewModel()
            {
                OperatingLocations = operatingLocationsService.All(ItemsPerPage, (page - 1) * ItemsPerPage).Select(x => new OperatingLocationViewModel 
                {
                    Id = x.Id,
                    Town = x.Town,
                    Address = x.Address,
                })
            };

            int count = this.operatingLocationsService.Count();
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;
            return this.View(viewModel);
        }

        //----------------------- DETAILS OF A OPERATING LOCATION --------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/OperatingLocations/Details/{id}</para>
        /// <para>Returns a View with details information for a <c>OperatingLocation</c>.</para>
        /// </summary>
        /// <param name="id">OperatingLocation ID</param>
        /// <returns>OperatingLocation details View</returns>
        [HttpGet]
        public IActionResult Details(int id)
        {
            OperatingLocationServiceModel operatingLocation = this.operatingLocationsService.GetById(id);
            if (operatingLocation.Town == null || operatingLocation.Address == null)
            {
                return this.BadRequest();
            }

            var model = new OperatingLocationDetailsViewModel
            {
                Id = operatingLocation.Id,
                Town = operatingLocation.Town,
                Address = operatingLocation.Address,
                // TODO: Add departments, employees and services table
            };

            return this.View(model);
        }

        //----------------------- EDIT A OPERATING LOCATION --------------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/OperatingLocations/Edit/{id}</para>
        /// <para>Returns a View with edit information of a <c>OperatingLocation</c>.</para>
        /// </summary>
        /// <param name="id">OperatingLocation ID</param>
        /// <returns>OperatingLocation edit View</returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            OperatingLocationServiceModel operatingLocation = this.operatingLocationsService.GetById(id);
            if (operatingLocation.Town == null || operatingLocation.Address == null)
            {
                return this.BadRequest();
            }

            var model = new OperatingLocationInputModel
            {
                Id = operatingLocation.Id,
                Town = operatingLocation.Town,
                Address = operatingLocation.Address,
                Description = operatingLocation.Description,
                ImageUrl = operatingLocation.ImageUrl,
                DepartmentIds = operatingLocation.DepartmentIds,
                Departments = this.departmentsService.GetAll().Select(x => new DepartmentsDropdownViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Phones = x.Phones.Select(x => new PhonesDropdownViewModel
                    {
                        Id = x.Id,
                        PhoneNumber = x.PhoneNumber,
                    })
                }),
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/OperatingLocations/Edit/{id}</para>
        /// <para>Edits a <c>OperatingLocation</c>.</para>
        /// </summary>
        /// <param name="model">Input model for editing a OperatingLocation</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(OperatingLocationInputModel model)
        {
            if (!this.operatingLocationsService.Exists(model.Id))
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            EditOperatingLocationServiceModel serviceModel = new EditOperatingLocationServiceModel
            {
                Id = model.Id,
                Town = model.Town,
                Address = model.Address,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                DepartmentIds = model.DepartmentIds,
            };

            await this.operatingLocationsService.EditAsync(serviceModel);
            return this.RedirectToAction("Details", "OperatingLocations", new { id = serviceModel.Id });
        }

        //----------------------- DELETION OF A OPERATING LOCATION -------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/OperatingLocations/Delete/{id}</para>
        /// <para>Returns a View with delete confirmation information for an <c>OperatingLocation</c>.</para>
        /// </summary>
        /// <param name="id">OperatingLocation ID</param>
        /// <returns>Delete operatingLocation confirmation View</returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            OperatingLocationServiceModel operatingLocation = this.operatingLocationsService.GetById(id);
            if (operatingLocation.Town == null || operatingLocation.Address == null)
            {
                return this.BadRequest();
            }

            var model = new DeleteOperatingLocationViewModel
            {
                Id = operatingLocation.Id,
                Town = operatingLocation.Town,
                Address = operatingLocation.Address,
                //TODO: Add departments, employees and service tables on delete view
            };

            return this.View(model);
        }

        // TODO: Implement delete on POST


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
