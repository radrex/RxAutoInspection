namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.JobPositions;
    using RxAuto.Services.Models.Qualifications;

    using RxAuto.Web.ViewModels.JobPositions.ViewModels;
    using RxAuto.Web.ViewModels.JobPositions.InputModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class JobPositions : Controller
    {
        //---------------- FIELDS -----------------
        private readonly IQualificationsService qualificationsService;
        private readonly IJobPositionsService jobPositionsService;
        private UnifiedModel unifiedModel;

        //------------- CONSTRUCTORS --------------
        public JobPositions(IQualificationsService qualificationsService, IJobPositionsService jobPositionsService)
        {
            this.qualificationsService = qualificationsService;
            this.jobPositionsService = jobPositionsService;
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        //----------------------- CREATE JOB POSITION VIEW FORM -----------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/JobPositions/Create/</para>
        /// <para>Initializes a <c>Unified Model</c> representing a collection of <see cref="JobPositionInputModel"/> and <see cref="QualificationInputModel"/> and passes it to the View.</para>
        /// <para>The View renders 2 Partial Views. The 1st gets <see cref="JobPositionInputModel"/> and the 2nd <see cref="QualificationInputModel"/>.</para>
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public IActionResult Create()
        {
            InitializeAndFillUnifiedModel();
            return this.View(this.unifiedModel);
        }

        //----------------------- CREATE FOR JOB POSITION FORM -----------------------
        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/JobPositions/Create/</para>
        /// <para>Initializes a <c>Unified Model</c> representing a collection of <see cref="JobPositionInputModel"/> and <see cref="QualificationInputModel"/> and passes it to the View.</para>
        /// <para>The View renders 2 Partial Views. The 1st gets <see cref="JobPositionInputModel"/> and the 2nd <see cref="QualificationInputModel"/>.</para>
        /// <para>On this action we get <see cref="JobPositionInputModel"/>, we use it's data to create and add a new <c>JobPosition</c> to the database.</para>
        /// </summary>
        /// <param name="model">JobPositionInputModel</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateJobPosition(JobPositionInputModel model)
        {
            InitializeAndFillUnifiedModel();

            if (!this.ModelState.IsValid)
            {
                return this.View("Create", this.unifiedModel);
            }

            var qualifications = new List<QualificationsListingServiceModel>();
            if (model.QualificationIds != null)
            {
                foreach (int qualificationId in model.QualificationIds)
                {
                    qualifications.Add(new QualificationsListingServiceModel
                    {
                        Id = qualificationId,
                    });
                }
            }

            var jobPosition = new CreateJobPositionServiceModel
            {
                Name = model.JobPositionName,
                Qualifications = qualifications,
            };

            await this.jobPositionsService.CreateAsync(jobPosition);
            return this.RedirectToAction("Create");
        }

        //----------------------- CREATE FOR QUALIFICATION FORM -----------------------
        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/JobPositions/Create/</para>
        /// <para>Initializes a <c>Unified Model</c> representing a collection of <see cref="JobPositionInputModel"/> and <see cref="QualificationInputModel"/> and passes it to the View.</para>
        /// <para>The View renders 2 Partial Views. The 1st gets <see cref="JobPositionInputModel"/> and the 2nd <see cref="QualificationInputModel"/>.</para>
        /// <para>On this action we get <see cref="QualificationInputModel"/>, we use it's data to create and add a new <c>Qualification</c> to the database.</para>
        /// </summary>
        /// <param name="model">QualificationInputModel</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateQualification(QualificationInputModel model)
        {
            InitializeAndFillUnifiedModel();
            if (!this.ModelState.IsValid)
            {
                return this.View("Create", this.unifiedModel);
            }

            var qualification = new CreateQualificationServiceModel
            {
                Name = model.QualificationName,
                Description = model.Description,
            };

            await this.qualificationsService.CreateAsync(qualification);
            return this.RedirectToAction("Create");
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           PRIVATE METHODS                                           //
        //-----------------------------------------------------------------------------------------------------//
        private void InitializeAndFillUnifiedModel()
        {
            this.unifiedModel = new UnifiedModel()
            {
                JobPositionInputModel = new JobPositionInputModel(),
                QualificationInputModel = new QualificationInputModel(),
            };

            var qualifications = qualificationsService.GetAll().Select(x => new QualificationsListingViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            this.unifiedModel.JobPositionInputModel.Qualifications = qualifications;
        }
    }
}
