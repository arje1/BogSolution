using BogAPI.Models;
using BogEntity.Entities.StoredProcedureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Extensions.SpExtensions
{
    public static class spGetSales_BasedOnFrequentAndProfitableProductsByConsultantsExtensions
    {
        public static spGetSales_BasedOnFrequentAndProfitableProductsByConsultantsDto TospGetSales_BasedOnFrequentAndProfitableProductsByConsultantsDto(this spGetSales_BasedOnFrequentAndProfitableProductsByConsultants spData)
        {
            spGetSales_BasedOnFrequentAndProfitableProductsByConsultantsDto DtoData = new spGetSales_BasedOnFrequentAndProfitableProductsByConsultantsDto
            {
                ConsultantCode = spData.ConsultantCode,
                ConsultantFullName = spData.ConsultantFullName,
                PrivateNumber = spData.PrivateNumber,
                BirthDate = spData.BirthDate,
                FrequentProductCode = spData.FrequentProductCode,
                FrequentProductName = spData.FrequentProductName,
                FrequentProductUnit = spData.FrequentProductUnit,
                ProfitableProductCode = spData.ProfitableProductCode,
                ProfitableProductName = spData.ProfitableProductName,
                ProfitableProductRevenue = spData.ProfitableProductRevenue
            };

            return DtoData;
        }

    }
}
