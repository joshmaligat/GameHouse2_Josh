using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHouse2_Josh.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        public string CustName { get; set; }
        public string CustEmail { get; set; }
        public string CustContact { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
