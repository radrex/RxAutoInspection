namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Web.ViewModels.VehicleTypes.ViewModels;
    using RxAuto.Web.ViewModels.VehicleTypes.InputModels;

    using RxAuto.Services.Data;
    using RxAuto.Services.Models.VehicleTypes;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class VehicleTypesController : Controller
    {
        //--------------- CONSTANTS ---------------
        private const int ItemsPerPage = 10;

        //---------------- FIELDS -----------------
        private readonly IVehicleTypesService vehicleTypesService;

        //------------- CONSTRUCTORS --------------
        public VehicleTypesController(IVehicleTypesService vehicleTypesService)
        {
            this.vehicleTypesService = vehicleTypesService;
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        //----------------------- LISTING FOR VEHICLE TYPES --------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/VehicleTypes/All/{page}</para>
        /// <para>Returns a View with VehicleTypes listing using Pagination.</para>
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns>View with VehicleTypes listing</returns>
        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var viewModel = new VehicleTypesListingViewModel()
            {
                VehicleTypes = this.vehicleTypesService.All(ItemsPerPage, (page - 1) * ItemsPerPage).Select(x => new VehicleTypeViewModel 
                {
                    Id = x.Id,
                    Name = x.Name,
                    VehicleCategory = x.VehicleCategory,
                }),
            };

            int count = this.vehicleTypesService.Count();
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;
            return this.View(viewModel);
        }

        //----------------------- DETAILS OF A VEHICLE TYPE --------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/VehicleTypes/Details/{id}</para>
        /// <para>Returns a View with details information for a <c>VehicleType</c>.</para>
        /// </summary>
        /// <param name="id">VehicleType ID</param>
        /// <returns>VehicleType details View</returns>
        [HttpGet]
        public IActionResult Details(int id)
        {
            VehicleTypeServiceModel vehicleType = this.vehicleTypesService.GetById(id);
            if (vehicleType.Name == null)
            {
                return this.BadRequest();
            }

            var model = new VehicleTypeDetailsViewModel
            {
                Id = vehicleType.Id,
                Name = vehicleType.Name,
                VehicleCategory = vehicleType.VehicleCategory.ToString(),
                Description = vehicleType.Description,
                // TODO: Add services table
            };

            return this.View(model);
        }

        //----------------------- EDIT A VEHICLE TYPE --------------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/VehicleTypes/Edit/{id}</para>
        /// <para>Returns a View with edit information of a <c>VehicleType</c>.</para>
        /// </summary>
        /// <param name="id">VehicleType ID</param>
        /// <returns>VehicleType edit View</returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            VehicleTypeServiceModel vehicleType = this.vehicleTypesService.GetById(id);
            if (vehicleType.Name == null)
            {
                return this.BadRequest();
            }

            var model = new VehicleTypeInputModel
            {
                Id = vehicleType.Id,
                VehicleTypeName = vehicleType.Name,
                VehicleTypeDescription = vehicleType.Description,
                VehicleCategoryId = vehicleType.VehicleCategoryId,
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/VehicleTypes/Edit/{id}</para>
        /// <para>Edits a <c>VehicleType</c>.</para>
        /// </summary>
        /// <param name="model">Input model for editing a VehicleType</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(VehicleTypeInputModel model)
        {
            if (!this.vehicleTypesService.Exists(model.Id))
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            EditVehicleTypeServiceModel serviceModel = new EditVehicleTypeServiceModel
            {
                Id = model.Id,
                Name = model.VehicleTypeName,
                Description = model.VehicleTypeDescription,
                VehicleCategoryId = model.VehicleCategoryId,
            };

            await this.vehicleTypesService.EditAsync(serviceModel);
            return this.RedirectToAction("Details", "VehicleTypes", new { id = serviceModel.Id });
        }

        //----------------------- DELETION OF A VEHICLE TYPE -------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/VehicleTypes/Delete/{id}</para>
        /// <para>Returns a View with delete confirmation information for a <c>VehicleType</c>.</para>
        /// </summary>
        /// <param name="id">VehicleType ID</param>
        /// <returns>Delete vehicleType confirmation View</returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            VehicleTypeServiceModel vehicleType = this.vehicleTypesService.GetById(id);
            if (vehicleType.Name == null)
            {
                return this.BadRequest();
            }

            var model = new DeleteVehicleTypeViewModel
            {
                Id = vehicleType.Id,
                Name = vehicleType.Name,
                Description = vehicleType.Description,
                VehicleCategory = vehicleType.VehicleCategory.ToString(),
                //TODO: Add services table on delete view
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/VehicleTypes/Delete/{id}</para>
        /// <para>Deletes the selected VehicleType.</para>
        /// </summary>
        /// <param name ="model">View model for deletion of a VehicleType</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteVehicleTypeViewModel model)
        {
            var success = await this.vehicleTypesService.RemoveAsync(model.Id);
            if (!success)
            {
                return this.RedirectToAction("Error", "Home"); // TODO: redirect
            }

            return this.RedirectToAction("All", "VehicleTypes");
        }
    }
}
