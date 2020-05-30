using BogAPI.Models;
using BogEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BogAPI.Extensions
{
    public static class ConsultantEntityExtensions
    {
        public static void UpdateValues(this Consultant consultantEntity, ConsultantDto consultantDto)
        {
            if (consultantDto != null)
            {
                consultantEntity.Code = consultantDto.Code;
                consultantEntity.FirstName = consultantDto.FirstName;
                consultantEntity.LastName = consultantDto.LastName;
                consultantEntity.PrivateNumber = consultantDto.PrivateNumber;
                consultantEntity.GenderId = consultantEntity.GenderId;
                consultantEntity.BirthDate = consultantEntity.BirthDate;
                consultantEntity.RecommendatorId = consultantEntity.RecommendatorId;
            }
        }

        public static ConsultantDto ToConsultantDto(this Consultant consultantEntity)
        {
            ConsultantDto consultantDto = new ConsultantDto
            {
                Id = consultantEntity.Id,
                Code = consultantEntity.Code,
                FirstName = consultantEntity.FirstName,
                LastName = consultantEntity.LastName,
                PrivateNumber = consultantEntity.PrivateNumber,
                GenderId = consultantEntity.GenderId,
                BirthDate = consultantEntity.BirthDate,
                RecommendatorId = consultantEntity.RecommendatorId
            };

            return consultantDto;
        }

       
        public static IEnumerable<Consultant> SelectWithSubConsultants(this DbSet<Consultant> consultans, int id)
        {
            List<Consultant> consultantWithSubConsultants = consultans
                                                            .FromSqlRaw<Consultant>("[Sales].[spConsultantWithSubConsultants]  {0}", id).ToList();

            return consultantWithSubConsultants;
        }


    }
}
