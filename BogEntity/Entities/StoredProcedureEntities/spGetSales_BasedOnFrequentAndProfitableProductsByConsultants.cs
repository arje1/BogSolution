using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BogEntity.Entities.StoredProcedureEntities
{
    public class spGetSales_BasedOnFrequentAndProfitableProductsByConsultants
    {

        public string ConsultantCode { get; set; }
        public string ConsultantFullName { get; set; }
        public string PrivateNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string FrequentProductCode { get; set; }
        public string FrequentProductName { get; set; }
        public int FrequentProductUnit { get; set; }
        public string ProfitableProductCode { get; set; }
        public string ProfitableProductName { get; set; }
        public double ProfitableProductRevenue { get; set; }




    }
}
