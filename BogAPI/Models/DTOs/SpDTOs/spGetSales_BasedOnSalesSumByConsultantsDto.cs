using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Models
{
    public class spGetSales_BasedOnSalesSumByConsultantsDto
    {
        public string ConsultantCode { get; set; }
        public string ConsultantFullName { get; set; }
        public DateTime ConsultantBirthDate { get; set; }
        public int SalesQuantity { get; set; }
        public int SalesQuantityIncludingSubConsultants { get; set; }

    }
}
