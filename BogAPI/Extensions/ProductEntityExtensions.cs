using BogAPI.Models;
using BogEntity.Entities;

namespace BogAPI.Extensions
{
    public static class ProductEntityExtensions
    {
        public static void UpdateValues(this Product productEntity, ProductDto productDto)
        {
            if (productDto != null)
            {
                productEntity.Code = productDto.Code;
                productEntity.Name = productDto.Name;
                productEntity.Price = productDto.Price;
            }
        }

        public static ProductDto ToProductDto(this Product productEntity)
        {
            ProductDto productDto = new ProductDto
            {
                Id = productEntity.Id,
                Code = productEntity.Code,
                Name = productEntity.Name,
                Price = productEntity.Price
            };

            return productDto;
        }
    }
}
