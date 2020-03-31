namespace RxAuto.Data.Models
{
    public class DepartmentPhone
    {
        //------------ Department [FK] -----------
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        //------------ Phone [FK] -----------
        public int PhoneId { get; set; }
        public virtual Phone Phone { get; set; }
    }
}
