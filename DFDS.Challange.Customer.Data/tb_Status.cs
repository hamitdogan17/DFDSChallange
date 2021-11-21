using System.Collections.Generic;

namespace DFDS.Challange.Customer.Data
{
    public class tb_Status
    {
        public tb_Status()
        {
            tb_Customer = new HashSet<tb_Customer>();
        }

        public int StatusRef { get; set; }
        public string Status { get; set; }

        public virtual ICollection<tb_Customer> tb_Customer { get; set; }
    }
}
