using System.Collections.Generic;

namespace DFDS.Challange.Customer.Data
{
    public class tb_Nationality
    {
        public tb_Nationality()
        {
            tb_Customer = new HashSet<tb_Customer>();
        }

        public int NationalityRef { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public virtual ICollection<tb_Customer> tb_Customer { get; set; }
    }
}
