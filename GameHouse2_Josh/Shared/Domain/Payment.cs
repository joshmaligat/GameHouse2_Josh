﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameHouse2_Josh.Shared.Domain
{
    public class Payment : BaseDomainModel
    {
        //public string PaymentType { get; set; }
        public double PaymentAmount { get; set; }
        public string PaymentMethod { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
