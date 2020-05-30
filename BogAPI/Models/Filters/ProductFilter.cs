using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Models.Filters
{
    public class ProductFilter
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double MinimumPrice { get; set; }
        public double MaximumPrice { get; set; }
    }
}
