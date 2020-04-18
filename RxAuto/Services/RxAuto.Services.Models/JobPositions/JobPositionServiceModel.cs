namespace RxAuto.Services.Models.JobPositions
{
    /// <summary>
    /// Service model for JobPosition information with <c>Id</c> and <c>Name</c>.
    /// </summary>
    public class JobPositionServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] QualificationIds { get; set; }
    }
}
