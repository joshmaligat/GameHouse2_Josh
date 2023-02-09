using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHouse2_Josh.Shared.Domain
{
    public class OrderItem : BaseDomainModel
    {
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Quantity is invalid, please input a number.")]
        public int OrderQty { get; set; }
        //public double OrderCost { get; set; }
        [Required]
        public int? OrderID { get; set; }
        public virtual Order Order { get; set; }
        [Required]
        public int? ProductID { get; set; }
        public virtual GamingProduct Product { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
