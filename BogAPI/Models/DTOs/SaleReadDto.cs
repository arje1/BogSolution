using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Models
{
    public class SaleReadDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime OperationDate { get; set; }
        public ConsultantDto Consultant { get; set; }
        public IEnumerable<ProductSaleReadDto> Products { get; set; }

    }
}
