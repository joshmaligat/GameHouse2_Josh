using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHouse2_Josh.Shared.Domain
{
    public class GamingProduct : BaseDomainModel
    {
        [Required]
        public string ProdName { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double ProdCost { get; set; }
        public string ProdDesc { get; set; }
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Stock is invalid, please input a number.")]
        public int ProdStock { get; set; }
        [Required]
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
