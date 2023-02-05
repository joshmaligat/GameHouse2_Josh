using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHouse2_Josh.Shared.Domain
{
    public class Order : BaseDomainModel
    {
        public string OrderNo { get; set; }
        public DateTime DateOut { get; set; }
        public double OrderTotalPrice { get; set; }
        public DateTime DateIn { get; set; }
        public int CustID { get; set; }
        public virtual Customer Customer { get; set; }
        public int ShipID { get; set; }
        public virtual ShippingAddress ShippingAddress { get; set; }
    }
}
