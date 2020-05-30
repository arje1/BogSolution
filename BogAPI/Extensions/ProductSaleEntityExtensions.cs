using BogAPI.Models;
using BogEntity.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Extensions
{
    public static class ProductSaleEntityExtensions
    {
        public static ProductSaleReadDto ToProductSaleReadDto(this ProductSale productSale)
        {
            ProductSaleReadDto productSaleReadDto = new ProductSaleReadDto
            {
                Id = productSale.ProductId,
                Code = productSale.Product.Code,
                Name = productSale.Product.Name,
                Unit = productSale.ProductUnit,
                PricePerUnit = productSale.PricePerUnit
            };

            return productSaleReadDto;
        }

    }
}
