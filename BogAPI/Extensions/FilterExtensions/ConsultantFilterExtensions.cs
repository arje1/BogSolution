using BogAPI.Models.Filters;
using BogEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Extensions.FilterExtensions
{
    public static class ConsultantFilterExtensions
    {

        public static IQueryable<Consultant> ApplyFilterParameters(this IQueryable<Consultant> source, ConsultantFilter consultantFilter)

        {
            if (consultantFilter == null)
            {
                return source;
            }

            if(consultantFilter.Id > 0)
            {
                source = source.Where(x => x.Id == consultantFilter.Id);
            }

            if (consultantFilter.Code != null && consultantFilter.Code.Trim() != string.Empty)
            {
                source = source.Where(x => x.Code == consultantFilter.Code);
            }

            if (consultantFilter.FirstName != null && consultantFilter.FirstName.Trim() != string.Empty)
            {
                source = source.Where(x => x.FirstName.ToLower().StartsWith(consultantFilter.FirstName.ToLower()));
            }

            if (consultantFilter.LastName != null && consultantFilter.LastName.Trim() != string.Empty)
            {
                source = source.Where(x => x.LastName.ToLower().StartsWith(consultantFilter.LastName.ToLower()));
            }

            if (consultantFilter.BirthYear > 1800)
            {
                source = source.Where(x => x.BirthDate.Year == consultantFilter.BirthYear);
            }

            if (consultantFilter.BirthMonth > 0 && consultantFilter.BirthMonth < 13)
            {
                source = source.Where(x => x.BirthDate.Month == consultantFilter.BirthMonth);
            }

            if (consultantFilter.BirthDay > 0 && consultantFilter.BirthDay < 32)
            {
                source = source.Where(x => x.BirthDate.Day == consultantFilter.BirthDay);
            }



            return source;
        }


    }
}

