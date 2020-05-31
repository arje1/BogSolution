using BogAPI.Models;
using BogAPI.Services.Interfaces;
using BogEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BogAPI.Extensions;
using BogAPI.Models.Paging;
using System.Linq.Dynamic.Core;
using BogAPI.Models.Filters;
using BogAPI.Extensions.FilterExtensions;

namespace BogAPI.Services
{
    public class ProductService : IProductService
    {

        private BogDBContext BogDBContext;
        private ProductDto ProductDto { get; set; }

        public ProductService(BogDBContext bogDBContext)
        {
            this.BogDBContext = bogDBContext;
        }


        public IProductService InitializeProduct(ProductDto productDto)
        {
            this.ProductDto = productDto;
            return this;
        }

        public int Create()
        {
            Product product = this.ProductDto.ToProductEntity();
            product.Id = 0;
            this.BogDBContext.Product.Add(product);
            this.BogDBContext.SaveChanges();

            return product.Id;
        }

        public IEnumerable<ProductDto> Read(PageRequest pageRequest, out PageResponse pageResponse, string orderBy = "", ProductFilter productFilter = null)
        {

            List<ProductDto> Products = BogDBContext.Product
                                        .ApplyFilterParameters(productFilter)
                                        .ApplyOrderParameters(orderBy)
                                        .TakePage(pageRequest, out pageResponse)
                                        .Select(x => x.ToProductDto()).ToList();
            return Products;
        }

        public int Update()
        {
            Product product = BogDBContext.Product.FirstOrDefault(x => x.Id == this.ProductDto.Id);
            if (product != null)
            {
                product.UpdateValues(this.ProductDto);
                BogDBContext.SaveChanges();
            }

            return product.Id;
        }

        public int Delete(int ProductId)
        {

            Product product = BogDBContext.Product.FirstOrDefault(x => x.Id == ProductId);
            BogDBContext.Product.Remove(product);

            return BogDBContext.SaveChanges();
        }


        public IValidateService ValidateCreation()
        {
            if (this.ProductDto == null)
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Product should be provided.";
                throw new BogApiException(null, ErrorModel);
            }

            if (BogDBContext.Product.Any(x => x.Code == this.ProductDto.Code))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Product Code should be unique.";
                throw new BogApiException(null, ErrorModel);
            }

            return this;
        }

        public IValidateService ValidateUpdate()
        {
            if (this.ProductDto == null)
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Product should be provided.";
                throw new BogApiException(null, ErrorModel);
            }

            if (this.ProductDto.Id <= 0)
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Product Id is not valid.";
                throw new BogApiException(null, ErrorModel);
            }

            if (this.ProductDto.Price < 0)
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Product Price is not valid.";
                throw new BogApiException(null, ErrorModel);
            }

            if (!BogDBContext.Product.Any(x => x.Id == this.ProductDto.Id))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Product doesn't exist.";
                throw new BogApiException(null, ErrorModel);
            }

            if (BogDBContext.Product.Any(x => x.Code == this.ProductDto.Code && x.Id != this.ProductDto.Id))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Product with the provided Code already exists.";
                throw new BogApiException(null, ErrorModel);
            }

            return this;
        }

        public IValidateService ValidateDelete(int id)
        {
            if (!BogDBContext.Product.Any(x => x.Id == id))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Product doesn't exist with the provided id.";
                throw new BogApiException(null, ErrorModel);
            }

            if (BogDBContext.ProductSale.Any(x => x.ProductId == id))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Product is in sales. It is not allowed to delete";
                throw new BogApiException(null, ErrorModel);
            }

            return this;
        }
    }
}
