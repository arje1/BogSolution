﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Models
{
    public class spGetSales_BasedOnProductPriceRangeDto
    {
        public string SaleCode { get; set; }
        public DateTime OperationDate { get; set; }
        public string ConsultantCode { get; set; }
        public string ConsultantFullName { get; set; }
        public string ConsultantPrivateNumber { get; set; }
        public int Products { get; set; }
    }
}
