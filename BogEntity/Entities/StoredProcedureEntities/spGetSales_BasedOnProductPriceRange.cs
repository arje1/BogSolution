using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BogEntity.Entities.StoredProcedureEntities
{
    public class spGetSales_BasedOnProductPriceRange
    {
        public string SaleCode { get; set; }
        public DateTime OperationDate { get; set; }
        public string ConsultantCode { get; set; }
        public string ConsultantFullName { get; set; }
        public string ConsultantPrivateNumber { get; set; }
        public int Products { get; set; }
    }
}
