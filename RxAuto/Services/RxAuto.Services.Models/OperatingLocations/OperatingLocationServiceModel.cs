namespace RxAuto.Services.Models.OperatingLocations
{
    public class OperatingLocationServiceModel
    {
        public int Id { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public string[] DepartmentIds { get; set; }
    }
}
