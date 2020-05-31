using BogAPI.Models;
using BogEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BogAPI.Extensions
{
    public static class SaleEntityExtensions
    {

        public static void UpdateValues(this Sale saleEntity, SaleSaveDto saleDto)
        {
            if (saleDto != null)
            {
                saleEntity.Code = saleDto.Code;
                saleEntity.OperationDate = saleDto.OperationDate;
                saleEntity.ConsultantId = saleDto.ConsultantId;
            }

        }


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
