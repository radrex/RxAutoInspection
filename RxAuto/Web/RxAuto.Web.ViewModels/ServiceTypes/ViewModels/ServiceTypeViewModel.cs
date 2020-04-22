namespace RxAuto.Web.ViewModels.ServiceTypes.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for listing a ServiceType's information such as <c>Id</c>, <c>Name</c> and <c>IsShownInMainMenu</c>.
    /// </summary>
    public class ServiceTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Job Position Name")]
        public string Name { get; set; }

        public string IsShownInMainMenu { get; set; }
    }
}
