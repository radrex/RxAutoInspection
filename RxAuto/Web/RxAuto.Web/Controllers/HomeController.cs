using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RxAuto.Services.Data;
using RxAuto.Web.Models;
using RxAuto.Web.ViewModels.Departments.ViewModels;
using RxAuto.Web.ViewModels.OperatingLocations.ViewModels;
using RxAuto.Web.ViewModels.Phones.ViewModels;

namespace RxAuto.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOperatingLocationsService operatingLocationsService;

        public HomeController(ILogger<HomeController> logger, IOperatingLocationsService operatingLocationsService)
        {
            _logger = logger;
            this.operatingLocationsService = operatingLocationsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult About()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            var viewModel = new OperatingLocationsViewModel
            {
                OperatingLocations = this.operatingLocationsService.AllInfo().Select(x => new OperatingLocationInfoViewModel
                {
                    Id = x.Id,
                    Town = x.Town,
                    Address = x.Address,
                    Departments = x.Departments.Select(x => new DepartmentInfoViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Email = x.Email,
                        Phones = x.Phones.Select(x => new PhoneViewModel
                        {
                            Id = x.Id,
                            PhoneNumber = x.PhoneNumber,
                            IsInternal = x.IsInternal,
                        })
                    })
                }).OrderBy(x => x.Town),
            };

            return this.View(viewModel);
        }
    }
}
