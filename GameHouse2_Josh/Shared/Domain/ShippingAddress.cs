using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHouse2_Josh.Shared.Domain
{
    public class ShippingAddress : BaseDomainModel
    {
        [Required]
        public string ShipAddress { get; set; }
        [Required]
        public string ShipCountry { get; set; }
        public string ShipState { get; set; }
        [Required]
        [RegularExpression(@"\d{1}\d{5}", ErrorMessage = "Postal Code is invalid.")]
        public string ShipPostalCode { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
