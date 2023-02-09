using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GameHouse2_Josh.Shared.Domain
{
    public class Order : BaseDomainModel, IValidatableObject
    {
        [Required]
        public string OrderNo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOut { get; set; }
        //public double OrderTotalPrice { get; set; }
        public DateTime? DateIn { get; set; }
        [Required]
        public int? CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        [Required]
        public int? ShippingAddressID { get; set; }
        public virtual ShippingAddress ShippingAddress { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //throw new NotImplementedException();

            if (DateIn != null)
            {
                if (DateIn <= DateOut)
                {
                    yield return new ValidationResult("DateIn must be greater than DateOut", new[] { "DateIn" });
                }
            }
        }
    }
}
