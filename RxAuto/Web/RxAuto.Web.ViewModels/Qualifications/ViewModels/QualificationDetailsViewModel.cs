using System.ComponentModel.DataAnnotations;

namespace RxAuto.Web.ViewModels.Qualifications.ViewModels
{
    public class QualificationDetailsViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Квалификация")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
