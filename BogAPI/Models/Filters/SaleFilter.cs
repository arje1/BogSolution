using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Models.Filters
{
    public class SaleFilter
    {
        public string SaleCode { get; set; }
        public DateTime? StartSaleDate { get; set; } = null;
        public DateTime? EndSaleDate { get; set; } = null;
        public int SaleDateYear { get; set; }
        public int SaleDateMonth { get; set; }
        public int SaleDateDay { get; set; }
        public string ConsultantCode { get; set; }
        public string ConsultantFirstName { get; set; }
        public string ConsultantLastName { get; set; }
        public string ConsultantPrivateNumber { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
    }
}
