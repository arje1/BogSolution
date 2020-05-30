using BogAPI.Models.Filters;
using BogEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Extensions.FilterExtensions
{
    public static class SaleFilterExtensions
    {

        public static IQueryable<Sale> ApplyFilterParameters(this IQueryable<Sale> source, SaleFilter saleFilter)
        {
            if (saleFilter == null)
            {
                return source;
            }

            if (saleFilter.SaleCode != null && saleFilter.SaleCode.Trim() != string.Empty)
            {
                source = source.Where(x => x.Code == saleFilter.SaleCode);
            }

            if (saleFilter.StartSaleDate.HasValue && saleFilter.StartSaleDate.Value > DateTime.MinValue)
            {
                source = source.Where(x => x.OperationDate >= saleFilter.StartSaleDate);
            }

            if (saleFilter.EndSaleDate.HasValue && saleFilter.EndSaleDate.Value > DateTime.MinValue)
            {
                source = source.Where(x => x.OperationDate <= saleFilter.EndSaleDate);
            }

            if (saleFilter.SaleDateYear > 0)
            {
                source = source.Where(x => x.OperationDate.Year == saleFilter.SaleDateYear);
            }

            if (saleFilter.SaleDateMonth > 0)
            {
                source = source.Where(x => x.OperationDate.Month == saleFilter.SaleDateMonth);
            }

            if (saleFilter.SaleDateDay > 0)
            {
                source = source.Where(x => x.OperationDate.Day == saleFilter.SaleDateDay);
            }

            if (saleFilter.ConsultantCode != null && saleFilter.ConsultantCode.Trim() != string.Empty)
            {
                source = source.Where(x => x.Consultant.Code == saleFilter.ConsultantCode);
            }

            if (saleFilter.ConsultantFirstName != null && saleFilter.ConsultantFirstName.Trim() != string.Empty)
            {
                source = source.Where(x => x.Consultant.FirstName.ToLower().StartsWith(saleFilter.ConsultantFirstName.ToLower()));
            }

            if (saleFilter.ConsultantLastName != null && saleFilter.ConsultantLastName.Trim() != string.Empty)
            {
                source = source.Where(x => x.Consultant.LastName.ToLower().StartsWith(saleFilter.ConsultantLastName.ToLower()));
            }

            if (saleFilter.ConsultantPrivateNumber != null && saleFilter.ConsultantPrivateNumber.Trim() != string.Empty)
            {
                source = source.Where(x => x.Consultant.PrivateNumber == saleFilter.ConsultantPrivateNumber);
            }


            if (saleFilter.ProductCode != null && saleFilter.ProductCode.Trim() != string.Empty)
            {
                source = source.Include(x => x.ProductSale).ThenInclude(x => x.Product).Where(x => x.ProductSale.Any(x => x.Product.Code == saleFilter.ProductCode));
            }

            if (saleFilter.ProductName != null && saleFilter.ProductName.Trim() != string.Empty)
            {
                source = source.Where(x => x.ProductSale.Any(x => x.Product.Name.StartsWith(saleFilter.ProductName)));
            }

            return source;
        }



    }
}
