namespace DFDS.Challange.Customer.Data
{
    public class tb_Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname{ get; set; }
        public string Mail{ get; set; }
        public string Address{ get; set; }
        public int Age { get; set; }
        public int NationalityRef { get; set; }
        public int StatusRef { get; set; }
        public bool IsDeleted { get; set; }

        public virtual tb_Nationality NationalityRefNavigation { get; set; }
        public virtual tb_Status StatusRefNavigation { get; set; }
    }
}
