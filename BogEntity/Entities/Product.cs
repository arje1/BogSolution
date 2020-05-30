using System;
using System.Collections.Generic;

namespace BogEntity.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<ProductSale> ProductSale { get; set; }
    }
}
