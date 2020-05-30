using BogEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BogAPI.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }


        #region DTO helper methods

        public Product ToProductEntity()
        {
            Product product = new Product
            {
                Id = this.Id,
                Code = this.Code,
                Name = this.Name,
                Price = this.Price
            };

            return product;
        }


        #endregion


    }


}
