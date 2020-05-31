using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BogAPI.Models;
using BogAPI.Models.Paging;
using BogAPI.Services.Interfaces;
using BogEntity.Entities.StoredProcedureEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public ActionResult<IEnumerable<spGetSales_BasedOnConsultantsDto>> GetSalesBasedOnConsultants(
            [FromQuery] DateTime startDate, [FromQuery] DateTime endDate,
            [FromQuery] PageRequest pageRequest = null)
        {

            var Result = AnalyticsService.GetSalesBasedOnConsultants(startDate, endDate, pageRequest, out PageResponse pageResponse);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageResponse));
            return Ok(Result);
        }

        [HttpGet("SalesBasedOnProductPriceRanges")]
        public ActionResult<IEnumerable<spGetSales_BasedOnProductPriceRangeDto>> GetSalesBasedOnProductPriceRanges(
           [FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] double minimumPrice, [FromQuery] double maximumPrice)
        {

            var Result = AnalyticsService.GetSales_BasedOnProductPriceRanges(startDate, endDate, minimumPrice, maximumPrice);

            return Ok(Result);
        }

        [HttpGet("SalesBasedOnFrequentProductsByConsultants")]
        public ActionResult<IEnumerable<spGetSales_BasedOnFrequentAndProfitableProductsByConsultantsDto>> GetSalesBasedOnFrequentProductsByConsultants(
          [FromQuery] DateTime startDate, [FromQuery] DateTime endDate, [FromQuery] int minimumUnit, [FromQuery] string productCode = "")
        {

            var Result = AnalyticsService.GetSales_BasedOnFrequentProductsByConsultants(startDate, endDate, minimumUnit, productCode);

            return Ok(Result);
        }

        [HttpGet("SalesBasedOnSalesSumByConsultants")]
        public ActionResult<IEnumerable<spGetSales_BasedOnSalesSumByConsultantsDto>> GetSalesBasedOnSalesSumByConsultants(
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
