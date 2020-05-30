using BogAPI.Models;
using BogEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BogAPI.Extensions
{
    public static class SaleEntityExtensions
    {
        public static SaleReadDto ToSaleReadDto(this Sale sale)
        {
            SaleReadDto saleReadDto = new SaleReadDto
            {
                Id = sale.Id,
                Code = sale.Code,
                OperationDate = sale.OperationDate,
                Consultant = sale.Consultant.ToConsultantDto(),
            };

            saleReadDto.Products = sale.ProductSale.Select(x => x.ToProductSaleReadDto()).ToList();

            return saleReadDto;
        }
    }
}
