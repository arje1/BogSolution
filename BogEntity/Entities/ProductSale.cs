using System;
using System.Collections.Generic;

namespace BogEntity.Entities
{
    public partial class ProductSale
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int ProductUnit { get; set; }
        public double PricePerUnit { get; set; }

        public Product Product { get; set; }
        public Sale Sale { get; set; }
    }
}
