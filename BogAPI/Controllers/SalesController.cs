using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BogAPI.Models;
using BogAPI.Models.Filters;
using BogAPI.Models.Paging;
using BogAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BogAPI.Controllers
{
    [Route("bogapi/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISaleService SaleService;
        public SalesController(ISaleService saleService)
        {
            SaleService = saleService;
        }

        [HttpGet]
        public ActionResult<string> Get([FromQuery] SaleFilter saleFilter = null,
            [FromQuery] string orderBy = null,
            [FromQuery] PageRequest pageRequest = null)
        {
            var Result = SaleService.Read(pageRequest, out PageResponse pageResponse, orderBy, saleFilter);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageResponse));
            return Ok(Result);
        }


        [HttpPost]
        public ActionResult<int> Add([FromBody] SaleSaveDto saleDto) => ((ISaleService)SaleService.InitializeSale(saleDto)
                                                                          .ValidateCreation())
                                                                          .Create();

        [HttpPut]
        public ActionResult<int> Update([FromBody] SaleSaveDto saleDto) => ((ISaleService)SaleService.InitializeSale(saleDto)
                                                                           .ValidateUpdate())
                                                                           .Update();




        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id) => ((ISaleService)SaleService
                                                    .ValidateDelete(id))
                                                    .Delete(id);




    }
}
