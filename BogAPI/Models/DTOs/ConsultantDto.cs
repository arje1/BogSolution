using BogEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Models
{
    public class ConsultantDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrivateNumber { get; set; }
        public int GenderId { get; set; }
        public DateTime BirthDate { get; set; }
        public int? RecommendatorId { get; set; }

        #region DTO helper methods
        public Consultant ToConsultantEntity()
        {
            Consultant consultant = new Consultant
            {
                Id = this.Id,
                Code = this.Code,
                FirstName = this.FirstName,
                LastName = this.LastName,
                PrivateNumber = this.PrivateNumber,
                GenderId = this.GenderId,
                BirthDate = this.BirthDate,
                RecommendatorId = this.RecommendatorId
            };

            return consultant;
        }


        #endregion
    }



}
