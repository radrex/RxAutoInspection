namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Web.ViewModels.ServiceTypes.ViewModels;
    using RxAuto.Web.ViewModels.ServiceTypes.InputModels;

    using RxAuto.Services.Data;
    using RxAuto.Services.Models.ServiceTypes;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class ServiceTypesController : Controller
    {
        //--------------- CONSTANTS ---------------
        private const int ItemsPerPage = 10;

        //---------------- FIELDS -----------------
        private readonly IServiceTypesService serviceTypesService;

        //------------- CONSTRUCTORS --------------
        public ServiceTypesController(IServiceTypesService serviceTypesService)
        {
            this.serviceTypesService = serviceTypesService;
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        //----------------------- LISTING FOR SERVICE TYPES --------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/ServiceTypes/All/{page}</para>
        /// <para>Returns a View with ServiceTypes listing using Pagination.</para>
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns>View with ServiceTypes listing</returns>
        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var viewModel = new ServiceTypesListingViewModel()
            {
                ServiceTypes = this.serviceTypesService.All(ItemsPerPage, (page - 1) * ItemsPerPage).Select(x => new ServiceTypeViewModel 
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsShownInMainMenu = x.IsShownInMainMenu,
                }),
            };

            int count = this.serviceTypesService.Count();
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;
            return this.View(viewModel);
        }

        //----------------------- DETAILS OF A SERVICE TYPE --------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/ServiceTypes/Details/{id}</para>
        /// <para>Returns a View with details information for a <c>ServiceType</c>.</para>
        /// </summary>
        /// <param name="id">ServiceType ID</param>
        /// <returns>ServiceType details View</returns>
        [HttpGet]
        public IActionResult Details(int id)
        {
            ServiceTypeServiceModel serviceType = this.serviceTypesService.GetById(id);
            if (serviceType.Name == null)
            {
                return this.BadRequest();
            }

            var model = new ServiceTypeDetailsViewModel
            {
                Id = serviceType.Id,
                Name = serviceType.Name,
                Description = serviceType.Description,
                IsShownInMainMenu = serviceType.IsShownInMainMenu == true ? "IsShownInMainMenu" : "NotShownInMainMenu",
                // TODO: Add Services table
            };

            return this.View(model);
        }

        //----------------------- EDIT A SERVICE TYPE --------------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/ServiceTypes/Edit/{id}</para>
        /// <para>Returns a View with edit information of a <c>ServiceType</c>.</para>
        /// </summary>
        /// <param name="id">ServiceType ID</param>
        /// <returns>ServiceType edit View</returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ServiceTypeServiceModel serviceType = this.serviceTypesService.GetById(id);
            if (serviceType.Name == null)
            {
                return this.BadRequest();
            }

            var model = new ServiceTypeInputModel
            {
                Id = serviceType.Id,
                ServiceTypeName = serviceType.Name,
                IsShownInMainMenu = serviceType.IsShownInMainMenu,
                ServiceTypeDescription = serviceType.Description,
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/ServiceTypes/Edit/{id}</para>
        /// <para>Edits a <c>ServiceType</c>.</para>
        /// </summary>
        /// <param name="model">Input model for editing a ServiceType</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(ServiceTypeInputModel model)
        {
            if (!this.serviceTypesService.Exists(model.Id))
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            EditServiceTypeServiceModel serviceModel = new EditServiceTypeServiceModel
            {
                Id = model.Id,
                Name = model.ServiceTypeName,
                Description = model.ServiceTypeDescription,
                IsShownInMainMenu = model.IsShownInMainMenu,
            };

            await this.serviceTypesService.EditAsync(serviceModel);
            return this.RedirectToAction("Details", "ServiceTypes", new { id = serviceModel.Id });
        }

        //----------------------- DELETION OF A SERVICE TYPE -------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/ServiceTypes/Delete/{id}</para>
        /// <para>Returns a View with delete confirmation information for a <c>ServiceType</c>.</para>
        /// </summary>
        /// <param name="id">ServiceType ID</param>
        /// <returns>Delete serviceType confirmation View</returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ServiceTypeServiceModel serviceType = this.serviceTypesService.GetById(id);
            if (serviceType.Name == null)
            {
                return this.BadRequest();
            }

            var model = new DeleteServiceTypeViewModel
            {
                Id = serviceType.Id,
                Name = serviceType.Name,
                Description = serviceType.Description,
                IsShownInMainMenu = serviceType.IsShownInMainMenu == true ? "IsShownInMainMenu" : "NotShownInMainMenu",
                //TODO: Add services table on delete view
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/ServiceTypes/Delete/{id}</para>
        /// <para>Deletes the selected ServiceType.</para>
        /// </summary>
        /// <param name="model"> View model for deletion of a ServiceType</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteServiceTypeViewModel model)
        {
            var success = await this.serviceTypesService.RemoveAsync(model.Id);
            if (!success)
            {
                return this.RedirectToAction("Error", "Home"); // TODO: redirect
            }

            return this.RedirectToAction("All", "ServiceTypes");
        }
    }
}
