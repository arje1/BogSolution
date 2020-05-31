using BogAPI.Models;
using BogAPI.Models.Paging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Services.Interfaces
{
    public interface IAnalyticsService
    {
        IEnumerable<spGetSales_BasedOnConsultantsDto> GetSalesBasedOnConsultants(DateTime startDate, DateTime endDate, PageRequest pageRequest, out PageResponse pageResponse);
        IEnumerable<spGetSales_BasedOnProductPriceRangeDto> GetSales_BasedOnProductPriceRanges(DateTime startDate, DateTime endDate, double minimumPrice, double maximumPrice);
        IEnumerable<spGetSales_BasedOnFrequentProductsByConsultantsDto> GetSales_BasedOnFrequentProductsByConsultants(DateTime startDate, DateTime endDate, int minimumUnit, string productCode = "");
        IEnumerable<spGetSales_BasedOnSalesSumByConsultantsDto> GetSales_BasedOnSalesSumByConsultants(DateTime? startDate = null, DateTime? endDate = null);
        IEnumerable<spGetSales_BasedOnFrequentAndProfitableProductsByConsultantsDto> GetSales_BasedOnFrequentAndProfitableProductsByConsultants(DateTime? startDate = null, DateTime? endDate = null);


    }
}
