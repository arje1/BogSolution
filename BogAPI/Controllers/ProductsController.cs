using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BogAPI.Models;
using BogAPI.Models.Filters;
using BogAPI.Models.Paging;
using BogAPI.Services;
using BogAPI.Services.Interfaces;
using BogEntity.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BogAPI.Controllers
{
    [Route("bogapi/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService ProductService;
        public ProductsController(IProductService productService)
        {
            ProductService = productService;
        }

        [HttpGet]
        public ActionResult<string> Get([FromQuery] ProductFilter productFilter = null,
            [FromQuery] string orderBy = null,
            [FromQuery] PageRequest pageRequest = null)
        {
            var Result = ProductService.Read(pageRequest, out PageResponse pageResponse, orderBy, productFilter);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(pageResponse));
            return Ok(Result);
        }


        [HttpPost]
        public ActionResult<string> Add([FromBody] ProductDto productDto)
        {
            var Result = ((IProductService)ProductService.InitializeProduct(productDto)
                        .ValidateCreation())
                        .Create();

            return Ok(Result);
        }

        [HttpPut]
        public ActionResult<string> Update([FromBody] ProductDto productDto)
        {
            var Result = ((IProductService)ProductService.InitializeProduct(productDto)
                       .ValidateUpdate())
                       .Update();

            return Ok(Result);
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            ((IProductService)ProductService
                       .ValidateDelete(id))
                       .Delete(id);
            return Ok();
        }
    }
}
