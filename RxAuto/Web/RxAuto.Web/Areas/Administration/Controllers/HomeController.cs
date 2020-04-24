namespace RxAuto.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [Area("Administration")]
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
