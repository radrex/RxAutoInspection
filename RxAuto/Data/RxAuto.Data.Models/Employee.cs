namespace RxAuto.Data.Models
{
    using RxAuto.Data.Models.Enums;
    public class Employee
    {
        //-------------- PROPERTIES ---------------
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public JobPosition JobPosition { get; set; }



        //TODO: do we include -> byte[] Image / URL link to image ?

        //------------ Town [FK] -----------
        public int TownId { get; set; }
        public Town WorkingTown { get; set; }


        //------------ ??? [FK] MAPPING TABLE -----------
        //TODO: Qualifications collection
    }
}
