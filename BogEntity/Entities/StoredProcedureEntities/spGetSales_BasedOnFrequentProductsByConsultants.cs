using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BogEntity.Entities.StoredProcedureEntities
{
    public class spGetSales_BasedOnFrequentProductsByConsultants
    {
        public string ConsultantCode { get; set; }
        public string ConsultantFullName { get; set; }
        public string ConsultantPrivateNumber { get; set; }
        public DateTime ConsultantBirthDate { get; set; }
        public string ProductCode { get; set; }
        public int ProductUnit { get; set; }

    }
}
