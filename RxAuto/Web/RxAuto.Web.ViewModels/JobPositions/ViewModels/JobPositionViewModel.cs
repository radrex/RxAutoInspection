namespace RxAuto.Web.ViewModels.JobPositions.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class JobPositionViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Работна Позиция")]
        public string Name { get; set; }

        // TODO: Add qualifications to view foreach jobPosition
    }
}
