namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Services.Data;
    using RxAuto.Services.Models.Phones;

    using RxAuto.Web.ViewModels.Phones.ViewModels;
    using RxAuto.Web.ViewModels.Phones.InputModels;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class PhonesController : Controller
    {
        //--------------- CONSTANTS ---------------
        private const int ItemsPerPage = 10;

        //---------------- FIELDS -----------------
        private readonly IPhonesService phonesService;

        //------------- CONSTRUCTORS --------------
        public PhonesController(IPhonesService phonesService)
        {
            this.phonesService = phonesService;
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        //----------------------- LISTING FOR PHONES --------------------------
        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var viewModel = new PhonesListingViewModel()
            {
                Phones = this.phonesService.All(ItemsPerPage, (page - 1) * ItemsPerPage).Select(x => new PhoneViewModel 
                {
                   Id = x.Id,
                   PhoneNumber = x.PhoneNumber,
                   IsInternal = x.IsInternal,
                }),
            };

            int count = this.phonesService.Count();
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;
            return this.View(viewModel);
        }

        //----------------------- DETAILS OF A PHONE --------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Phones/Details/{id}</para>
        /// <para>Returns a View with details information for a <c>Phone</c>.</para>
        /// </summary>
        /// <param name="id">Phone ID</param>
        /// <returns>Phone details View</returns>
        [HttpGet]
        public IActionResult Details(int id)
        {
            PhoneServiceModel phone = this.phonesService.GetById(id);
            if (phone.PhoneNumber == null)
            {
                return this.BadRequest();
            }

            var model = new PhoneDetailsViewModel
            {
                Id = phone.Id,
                PhoneNumber = phone.PhoneNumber,
                IsInternal = phone.IsInternal,
                // TODO: Add departments table
            };

            return this.View(model);
        }

        //----------------------- EDIT A PHONE --------------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Phones/Edit/{id}</para>
        /// <para>Returns a View with edit information of a <c>Phone</c>.</para>
        /// </summary>
        /// <param name="id">Phone ID</param>
        /// <returns>Phone edit View</returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            PhoneServiceModel phone = this.phonesService.GetById(id);
            if (phone.PhoneNumber == null)
            {
                return this.BadRequest();
            }

            var model = new PhoneInputModel
            {
                Id = phone.Id,
                PhoneNumber = phone.PhoneNumber,
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Phones/Edit/{id}</para>
        /// <para>Edits a <c>Phone</c>.</para>
        /// </summary>
        /// <param name="model">Input model for editing a Phone</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(PhoneInputModel model)
        {
            if (!this.phonesService.Exists(model.Id))
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            EditPhoneServiceModel serviceModel = new EditPhoneServiceModel
            {
                Id = model.Id,
                PhoneNumber = model.PhoneNumber,
            };

            await this.phonesService.EditAsync(serviceModel);
            return this.RedirectToAction("Details", "Phones", new { id = serviceModel.Id });
        }

        //----------------------- DELETION OF A PHONE -------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Phones/Delete/{id}</para>
        /// <para>Returns a View with delete confirmation information for a <c>Phone</c>.</para>
        /// </summary>
        /// <param name="id">Phone ID</param>
        /// <returns>Delete phone confirmation View</returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            PhoneServiceModel phone = this.phonesService.GetById(id);
            if (phone.PhoneNumber == null)
            {
                return this.BadRequest();
            }

            var model = new DeletePhoneViewModel
            {
                Id = phone.Id,
                PhoneNumber = phone.PhoneNumber,
                IsInternal = phone.IsInternal,
                // TODO: Add departments table on delete view
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Phones/Delete/{id}</para>
        /// <para>Deletes the selected phone.</para>
        /// </summary>
        /// <param name ="model">View model for deletion of a Phone</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(DeletePhoneViewModel model)
        {
            var success = await this.phonesService.RemoveAsync(model.Id);
            if (!success)
            {
                return this.RedirectToAction("Error", "Home"); // TODO: redirect
            }

            return this.RedirectToAction("All", "Phones");
        }

    }
}
