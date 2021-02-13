namespace RxAuto.Data.Seeding.JSONSeed
{
    using System.Collections.Generic;

    public class JSONData
    {
        public List<JQualification> Qualifications { get; set; }
        public List<JJobPosition> JobPositions { get; set; }
        public List<JOperatingLocation> OperatingLocations { get; set; }
        public List<JEmployee> Employees { get; set; }
        public List<JPhone> Phones { get; set; }
        public List<JDepartment> Departments { get; set; }
        public List<JDocument> Documents { get; set; }
        public List<JVehicleType> VehicleTypes { get; set; }
        public List<JServiceType> ServiceTypes { get; set; }
        public List<JService> Services { get; set; }
        public List<JReservation> Reservations { get; set; }
    }
}
