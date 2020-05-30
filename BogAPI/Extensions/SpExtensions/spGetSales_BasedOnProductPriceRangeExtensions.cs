using BogAPI.Models;
using BogEntity.Entities;
using BogEntity.Entities.StoredProcedureEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Extensions.SpExtensions
{
    public static class spGetSales_BasedOnProductPriceRangeExtensions
    {
        public static spGetSales_BasedOnProductPriceRangeDto TospGetSales_BasedOnProductPriceRangeDto(this spGetSales_BasedOnProductPriceRange spData)
        {
            spGetSales_BasedOnProductPriceRangeDto DtoData = new spGetSales_BasedOnProductPriceRangeDto
            {
                SaleCode = spData.SaleCode,
                OperationDate = spData.OperationDate,
                ConsultantCode = spData.ConsultantCode,
                ConsultantFullName = spData.ConsultantFullName,
                ConsultantPrivateNumber = spData.ConsultantPrivateNumber,
                Products = spData.Products
            };

            return DtoData;
        }
    }
}
