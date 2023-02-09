using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHouse2_Josh.Shared.Domain
{
    public class OrderItem : BaseDomainModel
    {
        public int OrderQty { get; set; }
        //public double OrderCost { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public int ProductID { get; set; }
        public virtual GamingProduct Product { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
