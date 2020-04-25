using System.ComponentModel.DataAnnotations;

namespace RxAuto.Web.ViewModels.Qualifications.ViewModels
{
    /// <summary>
    /// View model for Qualification information with <c>Id</c>, <c>Name</c> and <c>Description</c>.
    /// </summary>
    public class QualificationDetailsViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Квалификация")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
