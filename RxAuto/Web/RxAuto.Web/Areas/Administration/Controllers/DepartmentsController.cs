namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.Phones;
    using RxAuto.Services.Models.Departments;

    using RxAuto.Web.ViewModels.UnifiedModels;
    using RxAuto.Web.ViewModels.Phones.ViewModels;
    using RxAuto.Web.ViewModels.Phones.InputModels;
    using RxAuto.Web.ViewModels.Departments.InputModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class DepartmentsController : Controller
    {
        //---------------- FIELDS -----------------
        private readonly IPhonesService phonesService;
        private readonly IDepartmentsService departmentsService;
        private DepartmentPhoneUnifiedModel unifiedModel;

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
