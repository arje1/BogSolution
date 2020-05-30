using BogAPI.Models;
using BogEntity.Entities.StoredProcedureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Extensions.SpExtensions
{
    public static class spGetSales_BasedOnSalesSumByConsultantsExtensions
    {
        public static spGetSales_BasedOnSalesSumByConsultantsDto TospGetSales_BasedOnSalesSumByConsultantsDto(this spGetSales_BasedOnSalesSumByConsultants spData)
        {
            spGetSales_BasedOnSalesSumByConsultantsDto DtoData = new spGetSales_BasedOnSalesSumByConsultantsDto
            {
                ConsultantCode = spData.ConsultantCode,
                ConsultantFullName = spData.ConsultantFullName,
                ConsultantBirthDate = spData.ConsultantBirthDate,
                SalesQuantity = spData.SalesQuantity,
                SalesQuantityIncludingSubConsultants = spData.SalesQuantityIncludingSubConsultants
            };

            return DtoData;
        }

    }
}
