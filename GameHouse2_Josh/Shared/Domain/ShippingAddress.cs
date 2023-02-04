using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHouse2_Josh.Shared.Domain
{
    public class ShippingAddress : BaseDomainModel
    {
        public string ShipAddress { get; set; }
        public string ShipCountry { get; set; }
        public string ShipState { get; set; }
        public string ShipPostalCode { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
