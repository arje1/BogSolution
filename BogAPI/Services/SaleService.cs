using BogAPI.Extensions;
using BogAPI.Extensions.FilterExtensions;
using BogAPI.Models;
using BogAPI.Models.Filters;
using BogAPI.Models.Paging;
using BogAPI.Services.Interfaces;
using BogEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Services
{
    public class SaleService : ISaleService
    {
        private BogDBContext BogDBContext;

        private SaleCreateDto SaleDto { get; set; }

        public SaleService(BogDBContext bogDBContext)
        {
            BogDBContext = bogDBContext;
        }

        public ISaleService InitializeSale(SaleCreateDto saletDto)
        {
            this.SaleDto = saletDto;
            return this;
        }
        public int Create()
        {
            Sale sale = this.SaleDto.ToSaleEntity();
            foreach (var productSale in sale.ProductSale)
            {
                productSale.PricePerUnit = BogDBContext.Product.FirstOrDefault(x => x.Id == productSale.ProductId).Price;
            }


            BogDBContext.Sale.Add(sale);
            BogDBContext.SaveChanges();

            return sale.Id;
        }


        public IEnumerable<SaleReadDto> Read(PageRequest pageRequest, out PageResponse pageResponse, string orderBy = "", SaleFilter saleFilter = null)
        {
            List<SaleReadDto> Sales =
                this.BogDBContext.Sale
                .Include(x => x.Consultant)
                .Include(x => x.ProductSale)
                    .ThenInclude(y => y.Product)
                .ApplyFilterParameters(saleFilter)
                .ApplyOrderParameters(orderBy)
                .TakePage(pageRequest, out pageResponse)
                .Select(x => x.ToSaleReadDto())
                .ToList();

            return Sales;
        }

        public int Update()
        {
            //TODO: update sales
            throw new NotImplementedException();
        }

        public void Delete(int SaleId)
        {
            Sale sale = BogDBContext.Sale.FirstOrDefault(x => x.Id == SaleId);
            BogDBContext.Sale.Remove(sale);

            BogDBContext.SaveChanges();
        }

        public IValidateService ValidateCreation()
        {
            if (this.SaleDto == null)
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Sale should be provided.";
                throw new BogApiException(null, ErrorModel);
            }

            if (this.SaleDto.Products == null || !this.SaleDto.Products.Any())
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Product(s) should be provided.";
                throw new BogApiException(null, ErrorModel);
            }

            if (BogDBContext.Sale.Any(x => x.Code == this.SaleDto.Code))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Sale code should be unique.";
                throw new BogApiException(null, ErrorModel);
            }

            if (this.SaleDto.Products.Any(x => x.Unit <= 0))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Any productUnit is not valid.";
                throw new BogApiException(null, ErrorModel);
            }

            if (SaleDto.ConsultantId <= 0 || !BogDBContext.Consultant.Any(x => x.Id == this.SaleDto.ConsultantId))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Consultant Id is not valid. Consultant with the provided ConsultantId doesn't exist.";
                throw new BogApiException(null, ErrorModel);
            }

            if (this.SaleDto.Products.Any(x => x.Id <= 0 || !BogDBContext.Product.Any(p => p.Id == x.Id)))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Any productId is not valid. Product with the provided ProductId doesn't exist.";
                throw new BogApiException(null, ErrorModel);
            }


            return this;
        }

        public IValidateService ValidateDelete(int id)
        {
            if (!BogDBContext.Sale.Any(x => x.Id == id))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Sale doesn't exist with the provided id.";
                throw new BogApiException(null, ErrorModel);

            }
            return this;
        }

        public IValidateService ValidateUpdate()
        {
            //TODO: validate sale update
            return this;
        }
    }
}
