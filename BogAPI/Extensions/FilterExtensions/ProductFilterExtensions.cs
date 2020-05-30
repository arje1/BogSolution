using BogAPI.Models;
using BogAPI.Models.Filters;
using BogEntity.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Extensions.FilterExtensions
{
    public static class ProductFilterExtensions
    {
        public static IQueryable<Product> ApplyFilterParameters(this IQueryable<Product> source, ProductFilter productFilter)
        {

            if (productFilter == null)
            {
                return source;
            }

            if (productFilter.Id > 0)
            {
                source = source.Where(x => x.Id == productFilter.Id);
            }

            if (productFilter.Code != null && productFilter.Code.Trim() != "")
            {
                source = source.Where(x => x.Code == productFilter.Code);
            }


            if (productFilter.Name != null && productFilter.Name.Trim() != "")
            {
                source = source.Where(x => x.Name.StartsWith(productFilter.Name.Trim()));
            }

            if (productFilter.MinimumPrice > 0)
            {
                source = source.Where(x => x.Price >= productFilter.MinimumPrice);
            }

            if (productFilter.MaximumPrice > 0)
            {
                source = source.Where(x => x.Price <= productFilter.MaximumPrice);
            }



            return source;
        }

    }
}
