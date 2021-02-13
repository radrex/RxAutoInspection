namespace RxAuto.Data.Seeding.JSONSeed
{
    public class JDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int OperatingLocationId { get; set; }
        public int[] PhoneIds { get; set; }
    }
}
