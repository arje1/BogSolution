using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BogEntity.Entities.StoredProcedureEntities
{
    public class spGetSales_BasedOnSalesSumByConsultants
    {
        public string ConsultantCode { get; set; }
        public string ConsultantFullName { get; set; }
        public DateTime ConsultantBirthDate { get; set; }
        public int SalesQuantity { get; set; }
        public int SalesQuantityIncludingSubConsultants { get; set; }
    }
}
