namespace RxAuto.Web.Areas.Administration.Controllers
{
    using RxAuto.Web.ViewModels.Documents.ViewModels;
    using RxAuto.Web.ViewModels.Documents.InputModels;

    using RxAuto.Services.Data;
    using RxAuto.Services.Models.Documents;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class DocumentsController : Controller
    {
        //--------------- CONSTANTS ---------------
        private const int ItemsPerPage = 10;

        //---------------- FIELDS -----------------
        private readonly IDocumentsService documentsService;

        //------------- CONSTRUCTORS --------------
        public DocumentsController(IDocumentsService documentsService)
        {
            this.documentsService = documentsService;
        }

        //-----------------------------------------------------------------------------------------------------//
        //                                           ACTION METHODS                                            //
        //-----------------------------------------------------------------------------------------------------//

        //----------------------- LISTING FOR DOCUMENTS --------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Documents/All/{page}</para>
        /// <para>Returns a View with Documents listing using Pagination.</para>
        /// </summary>
        /// <param name="page">Page number</param>
        /// <returns>View with Documents listing</returns>
        [HttpGet]
        public IActionResult All(int page = 1)
        {
            var viewModel = new DocumentsListingViewModel()
            {
                Documents = this.documentsService.All(ItemsPerPage, (page - 1) * ItemsPerPage).Select(x => new DocumentViewModel 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                }),
            };

            int count = this.documentsService.Count();
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;
            return this.View(viewModel);
        }

        //----------------------- DETAILS OF A DOCUMENT --------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Documents/Details/{id}</para>
        /// <para>Returns a View with details information for a <c>Document</c>.</para>
        /// </summary>
        /// <param name="id">Document ID</param>
        /// <returns>Document details View</returns>
        [HttpGet]
        public IActionResult Details(int id)
        {
            DocumentServiceModel document = this.documentsService.GetById(id);
            if (document.Name == null)
            {
                return this.BadRequest();
            }

            var model = new DocumentDetailsViewModel
            {
                Id = document.Id,
                Name = document.Name,
                Description = document.Description,
                // TODO: Add services table
            };

            return this.View(model);
        }

        //----------------------- EDIT A DOCUMENT --------------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Documents/Edit/{id}</para>
        /// <para>Returns a View with edit information of a <c>Document</c>.</para>
        /// </summary>
        /// <param name="id">Document ID</param>
        /// <returns>Document edit View</returns>
        [HttpGet]
        public IActionResult Edit(int id)
        {
            DocumentServiceModel document = this.documentsService.GetById(id);
            if (document.Name == null)
            {
                return this.BadRequest();
            }

            var model = new DocumentInputModel
            {
                Id = document.Id,
                DocumentName = document.Name,
                DocumentDescription = document.Description,
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Documents/Edit/{id}</para>
        /// <para>Edits a <c>Document</c>.</para>
        /// </summary>
        /// <param name="model">Input model for editing a Document</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(DocumentInputModel model)
        {
            if (!this.documentsService.Exists(model.Id))
            {
                return this.BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            EditDocumentServiceModel serviceModel = new EditDocumentServiceModel
            {
                Id = model.Id,
                Name = model.DocumentName,
                Description = model.DocumentDescription,
            };

            await this.documentsService.EditAsync(serviceModel);
            return this.RedirectToAction("Details", "Documents", new { id = serviceModel.Id });
        }

        //----------------------- DELETION OF A DOCUMENT -------------------------
        /// <summary>
        /// Controller GET Action Method.
        /// <para>Active Route --> /Administration/Documents/Delete/{id}</para>
        /// <para>Returns a View with delete confirmation information for a <c>Document</c>.</para>
        /// </summary>
        /// <param name="id">Document ID</param>
        /// <returns>Delete document confirmation View</returns>
        [HttpGet]
        public IActionResult Delete(int id)
        {
            DocumentServiceModel document = this.documentsService.GetById(id);
            if (document.Name == null)
            {
                return this.BadRequest();
            }

            var model = new DeleteDocumentViewModel
            {
                Id = document.Id,
                Name = document.Name,
                Description = document.Description,
                //TODO: add services table on delete view
            };

            return this.View(model);
        }

        /// <summary>
        /// Controller POST Action Method.
        /// <para>Active Route --> /Administration/Documents/Delete/{id}</para>
        /// <para>Deletes the selected document.</para>
        /// </summary>
        /// <param name="model"> View model for deletion of a Document</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteDocumentViewModel model)
        {
            var success = await this.documentsService.RemoveAsync(model.Id);
            if (!success)
            {
                return this.RedirectToAction("Error", "Home"); // TODO: redirect
            }

            return this.RedirectToAction("All", "Documents");
        }

    }
}
