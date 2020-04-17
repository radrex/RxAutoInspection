namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.Qualifications;
    using RxAuto.Web.ViewModels.Qualifications.ViewModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using RxAuto.Web.ViewModels.Qualifications.InputModels;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class QualificationsController : Controller
    {
        //--------------- CONSTANTS ---------------
        private const int ItemsPerPage = 3;

        //---------------- FIELDS -----------------
        private readonly IQualificationsService qualificationsService;

        //------------- CONSTRUCTORS --------------
        public QualificationsController(IQualificationsService qualificationsService)
        {
            this.qualificationsService = qualificationsService;
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        //------------------------- LISTING FOR QUALIFICATIONS ----------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Qualifications/All/{page}</para>
        /// <para>Returns a View with Qualifications listing using Pagination.</para>
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns>View with Qualifications listing</returns>
        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var viewModel = new QualificationsListingViewModel()
            {
                Qualifications = qualificationsService.All(ItemsPerPage, (page - 1) * ItemsPerPage).Select(x => new QualificationViewModel 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                }),
            };

            int count = this.qualificationsService.Count();
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;
            return this.View(viewModel);
        }

        //------------------------- DETAILS OF A QUALIFICATION ----------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Qualifications/Details/{id}</para>
        /// <para>Returns a View with details information for a <c>Qualification</c>.</para>
        /// </summary>
        /// <param name="id">Qualification ID</param>
        /// <returns>Qualification details View</returns>
        [HttpGet]
        public IActionResult Details(int id)
        {
            QualificationServiceModel qualification = this.qualificationsService.GetById(id);
            if (qualification.Name == null)
            {
                return this.BadRequest();
            }

            var model = new QualificationDetailsViewModel
            {
                Id = qualification.Id,
                Name = qualification.Name,
                Description = qualification.Description,
                // TODO: Add job positions table
            };

            return this.View(model);
        }

        //------------------------- EDIT A QUALIFICATION ----------------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Qualifications/Edit/{id}</para>
        /// <para>Returns a View with edit information of a <c>Qualification</c>.</para>
        /// </summary>
        /// <param name="id">Qualification ID</param>
        /// <returns>Qualification edit View</returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            QualificationServiceModel qualification = this.qualificationsService.GetById(id);
            if (qualification.Name == null)
            {
                return this.BadRequest();
            }

            var model = new QualificationInputModel
            {
                Id = qualification.Id,
                QualificationName = qualification.Name,
                Description = qualification.Description,
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Qualifications/Edit/{id}</para>
        /// <para>Edits a <c>Qualification</c>.</para>
        /// </summary>
        /// <param name="model">Input model for editing a Qualification</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(QualificationInputModel model)
        {
            if (!this.qualificationsService.Exists(model.Id))
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            EditQualificationServiceModel serviceModel = new EditQualificationServiceModel
            {
                Id = model.Id,
                Name = model.QualificationName,
                Description = model.Description,
            };

            await this.qualificationsService.EditAsync(serviceModel);
            return this.RedirectToAction("Details", "Qualifications", new { id = serviceModel.Id });
        }

        //------------------------- DELETION OF A QUALIFICATION ---------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Qualifications/Delete/{id}</para>
        /// <para>Returns a View with delete confirmation information for a <c>Qualification</c>.</para>
        /// </summary>
        /// <param name="id">Qualification ID</param>
        /// <returns>Delete qualification confirmation View</returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            QualificationServiceModel qualification = this.qualificationsService.GetById(id);
            if (qualification.Name == null)
            {
                return this.BadRequest();
            }

            var model = new DeleteQualificationViewModel
            {
                Id = qualification.Id,
                Name = qualification.Name,
                Description = qualification.Description,
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Qualifications/Delete/{id}</para>
        /// <para>Deletes the selected qualification.</para>
        /// </summary>
        /// <param name="model">View model for deletion of a Qualification</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteQualificationViewModel model)
        {
            var success = await this.qualificationsService.RemoveAsync(model.Id);
            if (!success)
            {
                return this.RedirectToAction("Error", "Home"); // TODO: redirect
            }

            return this.RedirectToAction("All", "Qualifications");
        }
    }
}
