namespace RxAuto.Web.ViewModels.JobPositions.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// View model for listing a JobPosition's information such as <c>Id</c> and <c>Name</c>.
    /// </summary>
    public class JobPositionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Job Position Name")]
        public string Name { get; set; }

        // TODO: Add qualifications to view foreach jobPosition
    }
}
