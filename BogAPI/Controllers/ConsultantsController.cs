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
    public class ConsultantsController : ControllerBase
    {

        private readonly IConsultantService ConsultantService;

        public ConsultantsController(IConsultantService consultantService)
        {
            ConsultantService = consultantService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ConsultantDto>> Get([FromQuery] ConsultantFilter consultantFilter = null,
            [FromQuery] string orderBy = null,
            [FromQuery] PageRequest pageRequest = null)
        {
            var Result = ConsultantService.Read(pageRequest, out PageResponse pageResponse, orderBy, consultantFilter);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageResponse));
            return Ok(Result);
        }

        [HttpGet("{id}/subconsultants")]
        public ActionResult<IEnumerable<ConsultantDto>> GetWithSubConsultants(int id) => ConsultantService.ReadWithSubConcultants(id).ToList();


        [HttpPost]
        public ActionResult<int> Add([FromBody] ConsultantDto consultantDto) => ((IConsultantService)ConsultantService.InitializeConsultant(consultantDto)
                                                                                .ValidateCreation())
                                                                                .Create();


        [HttpPut]
        public ActionResult<int> Update([FromBody] ConsultantDto consultantDto) => ((IConsultantService)ConsultantService.InitializeConsultant(consultantDto)
                                                                                    .ValidateUpdate())
                                                                                    .Update();



        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id) => ((IConsultantService)ConsultantService
                                                    .ValidateDelete(id))
                                                    .Delete(id);

    }
}
