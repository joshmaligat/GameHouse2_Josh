using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHouse2_Josh.Shared.Domain
{
    public class Category : BaseDomainModel
    {
        //public string CategoryType { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
