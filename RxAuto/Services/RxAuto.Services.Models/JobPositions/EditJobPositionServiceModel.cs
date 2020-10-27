namespace RxAuto.Services.Models.JobPositions
{
    public class EditJobPositionServiceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] QualificationIds { get; set; }
    }
}
