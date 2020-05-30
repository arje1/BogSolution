using System;
using System.Collections.Generic;

namespace BogEntity.Entities
{
    public partial class Sale
    {

        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime OperationDate { get; set; }
        public int ConsultantId { get; set; }

        public Consultant Consultant { get; set; }
        public ICollection<ProductSale> ProductSale { get; set; }
    }
}
