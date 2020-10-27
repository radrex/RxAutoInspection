namespace RxAuto.Web.ViewModels.Qualifications.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class DeleteQualificationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Квалификация")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
