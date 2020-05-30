using BogAPI.Extensions.SpExtensions;
using BogAPI.Models;
using BogAPI.Services.Interfaces;
using BogEntity.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Services
{
    public class AnalitycsService : IAnalyticsService
    {
        private BogDBContext BogDBContext;

        public AnalitycsService(BogDBContext bogDBContext)
        {
            this.BogDBContext = bogDBContext;
        }


        public IEnumerable<spGetSales_BasedOnConsultantsDto> GetSalesBasedOnConsultants(DateTime startDate, DateTime endDate)
        {
            List<spGetSales_BasedOnConsultantsDto> Result =
                            BogDBContext.GetSalesBasedOnConsultants(startDate, endDate).Select(x => x.ToSpGetSales_BasedOnConsultantsDto()).ToList();


            return Result;
        }

        public IEnumerable<spGetSales_BasedOnProductPriceRangeDto> GetSales_BasedOnProductPriceRanges(DateTime startDate, DateTime endDate, double minimumPrice, double maximumPrice)
        {
            List<spGetSales_BasedOnProductPriceRangeDto> Result =
                            BogDBContext.GetSales_BasedOnProductPriceRanges(startDate, endDate, minimumPrice, maximumPrice).Select(x => x.TospGetSales_BasedOnProductPriceRangeDto()).ToList();


            return Result;
        }


        public IEnumerable<spGetSales_BasedOnFrequentProductsByConsultantsDto> GetSales_BasedOnFrequentProductsByConsultants(DateTime startDate, DateTime endDate, int minimumUnit, string productCode = "")
        {
            List<spGetSales_BasedOnFrequentProductsByConsultantsDto> Result =
                            BogDBContext.GetSales_BasedOnFrequentProductsByConsultants(startDate, endDate, minimumUnit, productCode).Select(x => x.TospGetSales_BasedOnFrequentProductsByConsultantsDto()).ToList();


            return Result;
        }

        public IEnumerable<spGetSales_BasedOnSalesSumByConsultantsDto> GetSales_BasedOnSalesSumByConsultants(DateTime? startDate = null, DateTime? endDate = null)
        {
            List<spGetSales_BasedOnSalesSumByConsultantsDto> Result =
                            BogDBContext.GetSales_BasedOnSalesSumByConsultants(startDate, endDate).Select(x => x.TospGetSales_BasedOnSalesSumByConsultantsDto()).ToList();


            return Result;
        }

        public IEnumerable<spGetSales_BasedOnFrequentAndProfitableProductsByConsultantsDto> GetSales_BasedOnFrequentAndProfitableProductsByConsultants(DateTime? startDate = null, DateTime? endDate = null)
        {
            List<spGetSales_BasedOnFrequentAndProfitableProductsByConsultantsDto> Result =
                            BogDBContext.GetSales_BasedOnFrequentAndProfitableProductsByConsultants(startDate, endDate).Select(x => x.TospGetSales_BasedOnFrequentAndProfitableProductsByConsultantsDto()).ToList();


            return Result;
        }


    }
}
