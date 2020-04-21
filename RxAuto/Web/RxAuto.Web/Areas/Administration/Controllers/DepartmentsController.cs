namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.Phones;
    using RxAuto.Services.Models.Departments;

    using RxAuto.Web.ViewModels.UnifiedModels;
    using RxAuto.Web.ViewModels.Phones.ViewModels;
    using RxAuto.Web.ViewModels.Phones.InputModels;
    using RxAuto.Web.ViewModels.Departments.ViewModels;
    using RxAuto.Web.ViewModels.Departments.InputModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class DepartmentsController : Controller
    {
        //--------------- CONSTANTS ---------------
        private const int ItemsPerPage = 10;

        //---------------- FIELDS -----------------
        private readonly IPhonesService phonesService;
        private readonly IDepartmentsService departmentsService;
        private readonly DepartmentPhoneUnifiedModel unifiedModel;

        //------------- CONSTRUCTORS --------------
        public DepartmentsController(IPhonesService phonesService, IDepartmentsService departmentsService)
        {
            this.phonesService = phonesService;
            this.departmentsService = departmentsService;
            this.unifiedModel = new DepartmentPhoneUnifiedModel
            {
                PhoneInputModel = new PhoneInputModel(),
                DepartmentInputModel = new DepartmentInputModel(),
            };
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        //----------------------- CREATE DEPARTMENT VIEW FORM -----------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Departments/Create/</para>
        /// <para>Initializes a <see cref="DepartmentPhoneUnifiedModel"/> representing a collection of <see cref="PhoneInputModel"/> and <see cref="DepartmentInputModel"/> and passes it to the View.</para>
        /// <para>The View renders 2 Partial Views. The 1st gets <see cref="PhoneInputModel"/> and the 2nd <see cref="DepartmentInputModel"/>.</para>
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public IActionResult Create()
        {
            this.FillUnifiedModel();
            return this.View(this.unifiedModel);
        }

        //-------------------------- CREATE FOR DEPARTMENT FORM --------------------------
        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Departments/Create/</para>
        /// <para>Initializes a <see cref="DepartmentPhoneUnifiedModel"/> representing a collection of <see cref="PhoneInputModel"/> and <see cref="DepartmentInputModel"/> and passes it to the View.</para>
        /// <para>The View renders 2 Partial Views. The 1st gets <see cref="PhoneInputModel"/> and the 2nd <see cref="DepartmentInputModel"/>.</para>
        /// <para>On this action we get <see cref="DepartmentInputModel"/>, we use it's data to create and add a new <c>Department</c> to the database.</para>
        /// </summary>
        /// <param name="model">JobPositionInputModel</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentInputModel model)
        {
            this.FillUnifiedModel();
            if (!this.ModelState.IsValid)
            {
                return this.View("Create", this.unifiedModel);
            }

            var phones = new List<PhonesDropdownServiceModel>();
            if (model.PhoneNumberIds != null)
            {
                foreach (int phoneNumberId in model.PhoneNumberIds)
                {
                    phones.Add(new PhonesDropdownServiceModel
                    {
                        Id = phoneNumberId,
                    });
                }
            }

            var department = new CreateDepartmentServiceModel
            {
                Name = model.Name,
                Email = model.Email,
                Description = model.Description,
                PhoneNumbers = phones,
            };

            await this.departmentsService.CreateAsync(department);
            return this.RedirectToAction("Create");
        }

        //-------------------------- CREATE FOR PHONE FORM --------------------------
        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Departments/Create/</para>
        /// <para>Initializes a <see cref="DepartmentPhoneUnifiedModel"/> representing a collection of <see cref="PhoneInputModel"/> and <see cref="DepartmentInputModel"/> and passes it to the View.</para>
        /// <para>The View renders 2 Partial Views. The 1st gets <see cref="PhoneInputModel"/> and the 2nd <see cref="DepartmentInputModel"/>.</para>
        /// <para>On this action we get <see cref="PhoneInputModel"/>, we use it's data to create and add a new <c>Phone</c> to the database.</para>
        /// </summary>
        /// <param name="model">PhoneInputModel</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreatePhone(PhoneInputModel model)
        {
            this.FillUnifiedModel();
            if (!this.ModelState.IsValid)
            {
                return this.View("Create", this.unifiedModel);
            }

            var phone = new CreatePhoneServiceModel
            {
                PhoneNumber = model.PhoneNumber,
            };

            await this.phonesService.CreateAsync(phone);
            return this.RedirectToAction("Create");
        }

        //-------------------------- LISTING FOR DEPARTMENTS ------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Departments/All/{page}</para>
        /// <para>Returns a View with Departments listing using Pagination.</para>
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns>View with Departments listing</returns>
        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var viewModel = new DepartmentsListingViewModel()
            {
                Departments = departmentsService.All(ItemsPerPage, (page - 1) * ItemsPerPage).Select(x => new DepartmentViewModel 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                }),
            };

            int count = this.departmentsService.Count();
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);
            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;
            return this.View(viewModel);
        }

        //-------------------------- DETAILS OF A DEPARTMENT ------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Departments/Details/{id}</para>
        /// <para>Returns a View with details information for a <c>Department</c>.</para>
        /// </summary>
        /// <param name="id">Department ID</param>
        /// <returns>Department details View</returns>
        [HttpGet]
        public IActionResult Details(int id)
        {
            DepartmentServiceModel department = this.departmentsService.GetById(id);
            if (department.Name == null)
            {
                return this.BadRequest();
            }

            var model = new DepartmentDetailsViewModel
            {
                Id = department.Id,
                Name = department.Name,
                Email = department.Email,
                Description = department.Description,
                // TODO: Add phones table
            };

            return this.View(model);
        }

        //-------------------------- EDIT A DEPARTMENT ------------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Departments/Edit/{id}</para>
        /// <para>Returns a View with edit information of a <c>Department</c>.</para>
        /// </summary>
        /// <param name="id">Department ID</param>
        /// <returns>Department edit View</returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            DepartmentServiceModel department = this.departmentsService.GetById(id);
            if (department.Name == null)
            {
                return this.BadRequest();
            }

            var model = new DepartmentInputModel
            {
                Id = department.Id,
                Name = department.Name,
                Email = department.Email,
                Description = department.Description,

                PhoneNumberIds = department.PhoneNumberIds,
                PhoneNumbers = this.phonesService.GetAll().Select(x => new PhonesDropdownViewModel
                {
                    Id = x.Id,
                    PhoneNumber = x.PhoneNumber,
                }),
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Departments/Edit/{id}</para>
        /// <para>Edits a <c>Department</c>.</para>
        /// </summary>
        /// <param name="model">Input model for editing a Department</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(DepartmentInputModel model)
        {
            if (!this.departmentsService.Exists(model.Id))
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            EditDepartmentServiceModel serviceModel = new EditDepartmentServiceModel
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Description = model.Description,
                PhoneNumberIds = (model.PhoneNumberIds == null) ? new int[0] : model.PhoneNumberIds,
            };

            await this.departmentsService.EditAsync(serviceModel);
            return this.RedirectToAction("Details", "Departments", new { id = serviceModel.Id });
        }

        //-------------------------- DELETION OF A DEPARTMENT -----------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Departments/Delete/{id}</para>
        /// <para>Returns a View with delete confirmation information for a <c>Department</c>.</para>
        /// </summary>
        /// <param name="id">Department ID</param>
        /// <returns>Delete department confirmation View</returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            DepartmentServiceModel department = this.departmentsService.GetById(id);
            if (department.Name == null)
            {
                return this.BadRequest();
            }

            var model = new DeleteDepartmentViewModel
            {
                Id = department.Id,
                Name = department.Name,
                Email = department.Email,
                Description = department.Description,
                //TODO: add phones table on delete view
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Departments/Delete/{id}</para>
        /// <para>Deletes the selected department.</para>
        /// </summary>
        /// <param name="model">View model for deletion of a Department</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteDepartmentViewModel model)
        {
            var success = await this.departmentsService.RemoveAsync(model.Id);
            if (!success)
            {
                return this.RedirectToAction("Error", "Home"); // TODO: redirect
            }

            return this.RedirectToAction("All", "Departments");
        }
        //-----------------------------------------------------------------------------------------------------//
        //                                           PRIVATE METHODS                                           //
        //-----------------------------------------------------------------------------------------------------//
        private void FillUnifiedModel()
        {
            var phones = this.phonesService.GetAll().Select(x => new PhonesDropdownViewModel
            {
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
            }).ToList();

            this.unifiedModel.DepartmentInputModel.PhoneNumbers = phones;
        }
    }
}
