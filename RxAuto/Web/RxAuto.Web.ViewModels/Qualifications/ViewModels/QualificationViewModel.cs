namespace RxAuto.Web.ViewModels.Qualifications.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for listing a Qualification's information such as <c>Id</c>, <c>Name</c> and <c>Description</c>.
    /// </summary>
    public class QualificationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Квалификация")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        // TODO: Add Job positions to view foreach qualification
    }
}
