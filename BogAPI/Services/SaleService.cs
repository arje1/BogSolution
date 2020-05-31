using BogAPI.Extensions;
using BogAPI.Extensions.FilterExtensions;
using BogAPI.Models;
using BogAPI.Models.Filters;
using BogAPI.Models.Paging;
using BogAPI.Services.Interfaces;
using BogEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BogAPI.Services
{
    public class SaleService : ISaleService
    {
        private BogDBContext BogDBContext;

        private SaleSaveDto SaleDto { get; set; }

        public SaleService(BogDBContext bogDBContext)
        {
            BogDBContext = bogDBContext;
        }

        public ISaleService InitializeSale(SaleSaveDto saletDto)
        {
            this.SaleDto = saletDto;
            return this;
        }
        public int Create()
        {
            Sale sale = this.SaleDto.ToSaleEntity();
            sale.Id = 0;
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
            Sale Sale = BogDBContext.Sale.Include(x => x.ProductSale).FirstOrDefault(x => x.Id == SaleDto.Id);
            if (Sale != null)
            {
                Sale.UpdateValues(this.SaleDto);
                var DeletedProducts = Sale.ProductSale.Where(x => !SaleDto.Products.Any(y => y.Id == x.ProductId)).ToList();
                var AddedProducts = SaleDto.Products.Where(x => !Sale.ProductSale.Any(y => y.ProductId == x.Id));
                var ChangedProducts = Sale.ProductSale.Where(x => (!DeletedProducts.Any(d => d.Id == x.Id)) && (!AddedProducts.Any(a => a.Id == x.ProductId)));


                foreach (var changedProduct in ChangedProducts)
                {
                    var changedProductDto = SaleDto.Products.FirstOrDefault(x => x.Id == changedProduct.Id);
                    if (changedProductDto != null && changedProduct.ProductUnit != changedProductDto.Unit)
                    {
                        BogDBContext.ProductSale.FirstOrDefault(x => x.Id == changedProduct.Id).ProductUnit = changedProductDto.Unit;
                    }
                }


                foreach (var deletedProduct in DeletedProducts)
                {
                    BogDBContext.ProductSale.Remove(deletedProduct);
                }
                foreach (var addedProduct in AddedProducts)
                {
                    ProductSale productSale = new ProductSale
                    {
                        SaleId = SaleDto.Id,
                        ProductId = addedProduct.Id,
                        ProductUnit = addedProduct.Unit,
                        PricePerUnit = BogDBContext.Product.FirstOrDefault(x => x.Id == addedProduct.Id).Price
                    };

                    BogDBContext.ProductSale.Add(productSale);
                }



                this.BogDBContext.SaveChanges();
            }

            return Sale.Id;
        }

        public int Delete(int SaleId)
        {
            Sale sale = BogDBContext.Sale.FirstOrDefault(x => x.Id == SaleId);
            BogDBContext.Sale.Remove(sale);

            return BogDBContext.SaveChanges();
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

            if (SaleDto.Products.Select(x => x.Id).Distinct().Count() != SaleDto.Products.Count())
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Different product Ids should be provided.";
                throw new BogApiException(null, ErrorModel);
            }

            if (this.SaleDto.Products.Any(x => x.Unit <= 0))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Any productUnit is not valid.";
                throw new BogApiException(null, ErrorModel);
            }

            if (BogDBContext.Sale.Any(x => x.Code == this.SaleDto.Code))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Sale code should be unique.";
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

            if (SaleDto.Products.Select(x => x.Id).Distinct().Count() != SaleDto.Products.Count())
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Different product Ids should be provided.";
                throw new BogApiException(null, ErrorModel);
            }

            if (this.SaleDto.Products.Any(x => x.Unit <= 0))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Any productUnit is not valid.";
                throw new BogApiException(null, ErrorModel);
            }

            if(this.SaleDto.Id <=0 || !BogDBContext.Sale.Any(x=>x.Id == this.SaleDto.Id))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Sale with the provided Id doesn't exist.";
                throw new BogApiException(null, ErrorModel);
            }

            if (BogDBContext.Sale.Any(x => x.Code == this.SaleDto.Code && x.Id != this.SaleDto.Id))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Sale code should be unique.";
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
    }
}
