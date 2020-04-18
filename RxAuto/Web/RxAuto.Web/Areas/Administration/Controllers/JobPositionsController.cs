namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.JobPositions;
    using RxAuto.Services.Models.Qualifications;

    using RxAuto.Web.ViewModels.UnifiedModels;
    using RxAuto.Web.ViewModels.JobPositions.ViewModels;
    using RxAuto.Web.ViewModels.JobPositions.InputModels;
    using RxAuto.Web.ViewModels.Qualifications.ViewModels;
    using RxAuto.Web.ViewModels.Qualifications.InputModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class JobPositions : Controller
    {
        //--------------- CONSTANTS ---------------
        private const int ItemsPerPage = 10;

        //---------------- FIELDS -----------------
        private readonly IQualificationsService qualificationsService;
        private readonly IJobPositionsService jobPositionsService;
        private readonly JobPositionQualificationUnifiedModel unifiedModel;

        //------------- CONSTRUCTORS --------------
        public JobPositions(IQualificationsService qualificationsService, IJobPositionsService jobPositionsService)
        {
            this.qualificationsService = qualificationsService;
            this.jobPositionsService = jobPositionsService;

            this.unifiedModel = new JobPositionQualificationUnifiedModel()
            {
                JobPositionInputModel = new JobPositionInputModel(),
                QualificationInputModel = new QualificationInputModel(),
            };
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        //----------------------- CREATE JOB POSITION VIEW FORM -----------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/JobPositions/Create/</para>
        /// <para>Initializes a <see cref="JobPositionQualificationUnifiedModel"/> representing a collection of <see cref="JobPositionInputModel"/> and <see cref="QualificationInputModel"/> and passes it to the View.</para>
        /// <para>The View renders 2 Partial Views. The 1st gets <see cref="JobPositionInputModel"/> and the 2nd <see cref="QualificationInputModel"/>.</para>
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public IActionResult Create()
        {
            this.InitializeAndFillUnifiedModel();
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
        /// <param name="model">Input model for entering JobPosition information from the user.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateJobPosition(JobPositionInputModel model)
        {
            this.InitializeAndFillUnifiedModel();

            if (!this.ModelState.IsValid)
            {
                return this.View("Create", this.unifiedModel);
            }

            var qualifications = new List<QualificationsDropdownServiceModel>();
            if (model.QualificationIds != null)
            {
                foreach (int qualificationId in model.QualificationIds)
                {
                    qualifications.Add(new QualificationsDropdownServiceModel
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
        /// <param name="model">Input model for entering Qualification information from the user.</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateQualification(QualificationInputModel model)
        {
            this.InitializeAndFillUnifiedModel();
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

        //----------------------- LISTING FOR JOB POSITIONS --------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/JobPositions/All/{page}</para>
        /// <para>Returns a View with JobPositions listing using Pagination.</para>
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns>View with JobPositions listing</returns>
        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var viewModel = new JobPositionsListingViewModel()
            {
                JobPositions = jobPositionsService.All(ItemsPerPage, (page - 1) * ItemsPerPage).Select(x => new JobPositionViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }),
            };

            int count = this.jobPositionsService.Count();
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;
            return this.View(viewModel);
        }

        //----------------------- DETAILS OF A JOB POSITION --------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/JobPositions/Details/{id}</para>
        /// <para>Returns a View with details information for a <c>JobPosition</c>.</para>
        /// </summary>
        /// <param name="id">JobPosition ID</param>
        /// <returns>JobPosition details View</returns>
        [HttpGet]
        public IActionResult Details(int id)
        {
            JobPositionServiceModel jobPosition = this.jobPositionsService.GetById(id);
            if (jobPosition.Name == null)
            {
                return this.BadRequest();
            }

            var model = new JobPositionDetailsViewModel
            {
                Id = jobPosition.Id,
                Name = jobPosition.Name,
                // TODO: Add qualifications table
            };

            return this.View(model);
        }

        //----------------------- EDIT A JOB POSITION --------------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/JobPositions/Edit/{id}</para>
        /// <para>Returns a View with edit information of a <c>JobPosition</c>.</para>
        /// </summary>
        /// <param name="id">JobPosition ID</param>
        /// <returns>JobPosition edit View</returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            JobPositionServiceModel jobPosition = this.jobPositionsService.GetById(id);
            if (jobPosition.Name == null)
            {
                return this.BadRequest();
            }

            var model = new JobPositionInputModel
            {
                Id = jobPosition.Id,
                JobPositionName = jobPosition.Name,

                QualificationIds = jobPosition.QualificationIds,
                Qualifications = this.qualificationsService.GetAll().Select(x => new QualificationsDropdownViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                }),
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/JobPositions/Edit/{id}</para>
        /// <para>Edits a <c>JobPosition</c>.</para>
        /// </summary>
        /// <param name="model">Input model for editing a JobPosition</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(JobPositionInputModel model)
        {
            if (!this.jobPositionsService.Exists(model.Id))
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            EditJobPositionServiceModel serviceModel = new EditJobPositionServiceModel
            {
                Id = model.Id,
                Name = model.JobPositionName,
                QualificationIds = model.QualificationIds,
            };

            await this.jobPositionsService.EditAsync(serviceModel);
            return this.RedirectToAction("Details", "JobPositions", new { id = serviceModel.Id });
        }

        //----------------------- DELETION OF A JOB POSITION -------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/JobPositions/Delete/{id}</para>
        /// <para>Returns a View with delete confirmation information for a <c>JobPosition</c>.</para>
        /// </summary>
        /// <param name="id">JobPosition ID</param>
        /// <returns>Delete jobPosition confirmation View</returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            JobPositionServiceModel jobPosition = this.jobPositionsService.GetById(id);
            if (jobPosition.Name == null)
            {
                return this.BadRequest();
            }

            var model = new DeleteJobPositionViewModel
            {
                Id = jobPosition.Id,
                Name = jobPosition.Name,
                //TODO: add qualifications table on delete view
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/JobPositions/Delete/{id}</para>
        /// <para>Deletes the selected jobPosition.</para>
        /// </summary>
        /// <param name = "model" > View model for deletion of a JobPosition</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteJobPositionViewModel model)
        {
            var success = await this.jobPositionsService.RemoveAsync(model.Id);
            if (!success)
            {
                return this.RedirectToAction("Error", "Home"); // TODO: redirect
            }

            return this.RedirectToAction("All", "JobPositions");
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           PRIVATE METHODS                                           //
        //-----------------------------------------------------------------------------------------------------//
        private void InitializeAndFillUnifiedModel()
        {
            var qualifications = qualificationsService.GetAll().Select(x => new QualificationsDropdownViewModel
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            this.unifiedModel.JobPositionInputModel.Qualifications = qualifications;
        }
    }
}
