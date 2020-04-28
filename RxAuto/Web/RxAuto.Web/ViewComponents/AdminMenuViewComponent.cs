namespace RxAuto.Web.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ViewComponent(Name = "AdminMenu")]
    public class AdminMenuViewComponent : ViewComponent
    {
        //------------- CONSTRUCTORS --------------
        public AdminMenuViewComponent()
        {

        }

        public IViewComponentResult Invoke()
        {
            return this.View();
        }

    }
}
