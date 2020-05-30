using BogAPI.Models;
using BogEntity.Entities;
using BogEntity.Entities.StoredProcedureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Extensions.SpExtensions
{
    public static class spGetSales_BasedOnConsultantsExtensions
    {
        public static spGetSales_BasedOnConsultantsDto ToSpGetSales_BasedOnConsultantsDto(this spGetSales_BasedOnConsultants spData)
        {
            spGetSales_BasedOnConsultantsDto DtoData = new spGetSales_BasedOnConsultantsDto
            {
                SaleCode = spData.SaleCode,
                OperationDate = spData.OperationDate,
                ConsultantCode = spData.ConsultantCode,
                ConsultantFullName = spData.ConsultantFullName,
                ConsultantPrivateNumber = spData.ConsultantPrivateNumber,
                ProductUnitSum = spData.ProductUnitSum,
                ProductPriceSum = spData.ProductPriceSum
            };

            return DtoData;
        }

    }
}
