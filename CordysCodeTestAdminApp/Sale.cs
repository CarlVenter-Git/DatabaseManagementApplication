﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CordysCodeTestAdminApp
{
    class Sale
    {
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int StoreID { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
    }
}
