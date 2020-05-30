using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BogAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BogAPI.Controllers
{
    [Route("bogapi/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {

        private readonly IAnalyticsService AnalyticsService;

        public AnalyticsController(IAnalyticsService analyticsService)
        {
            AnalyticsService = analyticsService;
        }


        [HttpGet("SalesBasedOnConsultants")]
        public ActionResult<string> GetSalesBasedOnConsultants(
            [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {

            var Result = AnalyticsService.GetSalesBasedOnConsultants(startDate, endDate);

            return Ok(Result);
        }

        [HttpGet("SalesBasedOnProductPriceRanges")]
        public ActionResult<string> GetSalesBasedOnProductPriceRanges(
           [FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] double minimumPrice, [FromQuery] double maximumPrice)
        {

            var Result = AnalyticsService.GetSales_BasedOnProductPriceRanges(startDate, endDate, minimumPrice, maximumPrice);

            return Ok(Result);
        }

        [HttpGet("SalesBasedOnFrequentProductsByConsultants")]
        public ActionResult<string> GetSalesBasedOnFrequentProductsByConsultants(
          [FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] int minimumUnit, [FromQuery] string productCode = "")
        {

            var Result = AnalyticsService.GetSales_BasedOnFrequentProductsByConsultants(startDate, endDate, minimumUnit, productCode);

            return Ok(Result);
        }

        [HttpGet("SalesBasedOnSalesSumByConsultants")]
        public ActionResult<string> GetSalesBasedOnSalesSumByConsultants(
         [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
        {
            var Result = AnalyticsService.GetSales_BasedOnSalesSumByConsultants(startDate, endDate);

            return Ok(Result);
        }

        [HttpGet("SalesBasedOnFrequentAndProfitableProductsByConsultants")]
        public ActionResult<string> GetSalesBasedOnFrequentAndProfitableProductsByConsultants(
        [FromQuery] DateTime? startDate = null, [FromQuery] DateTime? endDate = null)
        {
            var Result = AnalyticsService.GetSales_BasedOnFrequentAndProfitableProductsByConsultants(startDate, endDate);

            return Ok(Result);
        }


    }
}
