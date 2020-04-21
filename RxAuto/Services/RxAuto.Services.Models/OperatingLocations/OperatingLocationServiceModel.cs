namespace RxAuto.Services.Models.OperatingLocations
{
    /// <summary>
    /// Service model for OperatingLocation information with <c>Id</c>, <c>Town</c>, <c>Address</c>, <c>Description</c>, <c>ImageUrl</c> and a collection of <c>DepartmentIds</c> with associated <c>PhoneIds</c>.
    /// </summary>
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
