using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Linq.Dynamic.Core;
using System.Runtime.CompilerServices;
using BogEntity.Entities;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using BogAPI.Models.Paging;
using System.Reflection;

namespace BogAPI.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> TakePage<T>(this IQueryable<T> source, PageRequest pageRequest)
        {
            if (pageRequest == null)
            {
                pageRequest = new PageRequest();
            }

            var ResultQuerable = source.Skip((pageRequest.PageNumber - 1) * pageRequest.PageSize)
                                       .Take(pageRequest.PageSize);

            return ResultQuerable;
        }

        public static IQueryable<T> TakePage<T>(this IQueryable<T> source, PageRequest pageRequest, out PageResponse pageResponse)
        {
            if (pageRequest == null)
            {
                pageRequest = new PageRequest();
            }

            var ResultQuerable = source.Skip((pageRequest.PageNumber - 1) * pageRequest.PageSize)
                                       .Take(pageRequest.PageSize);

            pageResponse = new PageResponse
            {
                CurrentPage = pageRequest.PageNumber,
                PageSize = pageRequest.PageSize,
                TotalCount = source.Count()
            };

            return ResultQuerable;
        }

        public static IQueryable<T> ApplyOrderParameters<T>(this IQueryable<T> source, string orderParameters)
        {
            if (orderParameters == null || orderParameters.TrimEnd() == string.Empty) { return source; }

            var orderParams = orderParameters.Trim().Split(',');
            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            return source.OrderBy(orderQuery);

        }

        


    }
}
