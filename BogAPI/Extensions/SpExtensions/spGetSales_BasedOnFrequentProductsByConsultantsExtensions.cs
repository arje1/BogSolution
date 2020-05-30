using BogAPI.Models;
using BogEntity.Entities.StoredProcedureEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Extensions.SpExtensions
{
    public static class spGetSales_BasedOnFrequentProductsByConsultantsExtensions
    {
        public static spGetSales_BasedOnFrequentProductsByConsultantsDto TospGetSales_BasedOnFrequentProductsByConsultantsDto(this spGetSales_BasedOnFrequentProductsByConsultants spData)
        {
            spGetSales_BasedOnFrequentProductsByConsultantsDto DtoData = new spGetSales_BasedOnFrequentProductsByConsultantsDto
            {
                ConsultantCode = spData.ConsultantCode,
                ConsultantFullName = spData.ConsultantFullName,
                ConsultantPrivateNumber = spData.ConsultantPrivateNumber,
                ConsultantBirthDate = spData.ConsultantBirthDate,
                ProductCode = spData.ProductCode,
                ProductUnit = spData.ProductUnit
            };
            return DtoData;
        }
    }
}
