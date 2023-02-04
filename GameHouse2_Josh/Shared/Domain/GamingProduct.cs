using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHouse2_Josh.Shared.Domain
{
    public class GamingProduct : BaseDomainModel
    {
        public string ProdName { get; set; }
        public double ProdCost { get; set; }
        public string ProdDesc { get; set; }
        public int ProdStock { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
