using BogEntity.Entities.StoredProcedureEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BogEntity.Entities
{
    public partial class BogDBContext
    {
        public List<spGetSales_BasedOnConsultants> GetSalesBasedOnConsultants(DateTime startDate,
                                                                              DateTime endDate,
                                                                              int pageNumber,
                                                                              int pageSize,
                                                                              out int totalNumber)
        {
            List<spGetSales_BasedOnConsultants> SalesBasedOnConsultants;


            string SqlQuery = @"[Analytics].[spGetSales_BasedOnConsultants]  @StartDate = {0}, @EndDate = {1}, @PageNumber = {2}, @PageSize = {3}";

            SalesBasedOnConsultants = this.Set<spGetSales_BasedOnConsultants>()
                                        .FromSqlRaw<spGetSales_BasedOnConsultants>(SqlQuery, startDate, endDate, pageNumber, pageSize).ToList();

            totalNumber = SalesBasedOnConsultants.First() == null ? 0 : SalesBasedOnConsultants.First().TotalNumber;
            return SalesBasedOnConsultants;
        }

        public List<spGetSales_BasedOnProductPriceRange> GetSales_BasedOnProductPriceRanges(DateTime startDate, DateTime endDate, double minimumPrice, double maximumPrice)
        {
            List<spGetSales_BasedOnProductPriceRange> Sales_BasedOnProductPriceRange;

            string SqlQuery = "[Analytics].[spGetSales_BasedOnProductPriceRange]  @StartDate = {0}, @EndDate = {1}, @MinimumPrice = {2}, @MaximumPrice = {3}";

            Sales_BasedOnProductPriceRange = this.Set<spGetSales_BasedOnProductPriceRange>()
                                .FromSqlRaw<spGetSales_BasedOnProductPriceRange>(SqlQuery, startDate, endDate, minimumPrice, maximumPrice).ToList();

            return Sales_BasedOnProductPriceRange;

        }

        public List<spGetSales_BasedOnFrequentProductsByConsultants> GetSales_BasedOnFrequentProductsByConsultants(DateTime startDate, DateTime endDate, int minimumUnit, string productCode = "")
        {

            List<spGetSales_BasedOnFrequentProductsByConsultants> Sales_BasedOnFrequentProductsByConsultants;

            string SqlQuery = "[Analytics].[spGetSales_BasedOnFrequentProductsByConsultants]  @StartDate = {0}, @EndDate = {1}, @MinimumUnit = {2}, @ProductCode = {3}";

            Sales_BasedOnFrequentProductsByConsultants = this.Set<spGetSales_BasedOnFrequentProductsByConsultants>()
                                .FromSqlRaw<spGetSales_BasedOnFrequentProductsByConsultants>(SqlQuery, startDate, endDate, minimumUnit, productCode).ToList();

            return Sales_BasedOnFrequentProductsByConsultants;

        }

        public List<spGetSales_BasedOnSalesSumByConsultants> GetSales_BasedOnSalesSumByConsultants(DateTime? startDate = null, DateTime? endDate = null)
        {
            List<spGetSales_BasedOnSalesSumByConsultants> Sales_BasedOnSalesSumByConsultants;

            string SqlQuery = "[Analytics].[spGetSales_BasedOnSalesSumByConsultants]  @StartDate = {0}, @EndDate = {1}";

            Sales_BasedOnSalesSumByConsultants = this.Set<spGetSales_BasedOnSalesSumByConsultants>()
                                .FromSqlRaw<spGetSales_BasedOnSalesSumByConsultants>(SqlQuery, startDate, endDate).ToList();

            return Sales_BasedOnSalesSumByConsultants;

        }

        public List<spGetSales_BasedOnFrequentAndProfitableProductsByConsultants> GetSales_BasedOnFrequentAndProfitableProductsByConsultants(DateTime? startDate = null, DateTime? endDate = null)
        {
            List<spGetSales_BasedOnFrequentAndProfitableProductsByConsultants> BasedOnFrequentAndProfitableProductsByConsultants;

            string SqlQuery = "[Analytics].[spGetSales_BasedOnFrequentAndProfitableProductsByConsultants]  @StartDate = {0}, @EndDate = {1}";

            BasedOnFrequentAndProfitableProductsByConsultants = this.Set<spGetSales_BasedOnFrequentAndProfitableProductsByConsultants>()
                                .FromSqlRaw<spGetSales_BasedOnFrequentAndProfitableProductsByConsultants>(SqlQuery, startDate, endDate).ToList();

            return BasedOnFrequentAndProfitableProductsByConsultants;

        }
    }
}
