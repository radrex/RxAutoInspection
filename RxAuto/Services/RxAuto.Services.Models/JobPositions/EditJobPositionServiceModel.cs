namespace RxAuto.Services.Models.JobPositions
{
    /// <summary>
    /// Service model for Qualification edit information with <c>Id</c>, <c>Name</c> and a collection of <c>QualificationIds</c>.
    /// </summary>
    public class EditJobPositionServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] QualificationIds { get; set; }
    }
}
