using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Models
{
    public class spGetSales_BasedOnFrequentProductsByConsultantsDto
    {
        public string ConsultantCode { get; set; }
        public string ConsultantFullName { get; set; }
        public string ConsultantPrivateNumber { get; set; }
        public DateTime ConsultantBirthDate { get; set; }
        public string ProductCode { get; set; }
        public int ProductUnit { get; set; }

    }
}
