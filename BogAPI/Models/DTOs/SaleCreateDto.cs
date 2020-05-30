using BogEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Models
{
    public class SaleCreateDto
    {

        //private BogDBContext BogDBContext;

        //public SaleCreateDto(BogDBContext bogDBContext)
        //{
        //    this.BogDBContext = bogDBContext;
        //}

        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime OperationDate { get; set; }
        public int ConsultantId { get; set; }
        public IEnumerable<ProductSaleCreateDto> Products { get; set; }

        #region DTO helper methods
        public Sale ToSaleEntity()
        {
            Sale sale = new Sale
            {
                Id = this.Id,
                Code = this.Code,
                OperationDate = this.OperationDate,
                ConsultantId = this.ConsultantId

            };

            sale.ProductSale = new List<ProductSale>();
            foreach (ProductSaleCreateDto productSaleDto in this.Products)
            {
                ProductSale productSale = new ProductSale();
                productSale.SaleId = this.Id;
                productSale.ProductId = productSaleDto.Id;
                productSale.ProductUnit = productSaleDto.Unit;

                sale.ProductSale.Add(productSale);
            }


            return sale;
        }

        #endregion


    }
}
