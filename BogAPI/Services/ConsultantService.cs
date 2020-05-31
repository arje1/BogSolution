using BogEntity.Entities;
using BogAPI.Models;
using BogAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BogAPI.Extensions;
using BogAPI.Models.Paging;
using BogAPI.Models.Filters;
using BogAPI.Extensions.FilterExtensions;

namespace BogAPI.Services
{
    public class ConsultantService : IConsultantService
    {
        private BogDBContext BogDBContext;
        private ConsultantDto ConsultantDto { get; set; }
        public ConsultantService(BogDBContext bogDBContext)
        {
            this.BogDBContext = bogDBContext;
        }

        public IConsultantService InitializeConsultant(ConsultantDto consultantDto)
        {
            this.ConsultantDto = consultantDto;
            return this;
        }

        public int Create()
        {
            Consultant consultant = this.ConsultantDto.ToConsultantEntity();
            consultant.Id = 0;
            this.BogDBContext.Consultant.Add(consultant);
            this.BogDBContext.SaveChanges();

            return consultant.Id;
        }


        public IEnumerable<ConsultantDto> Read(PageRequest pageRequest, out PageResponse pageResponse, string orderBy = "", ConsultantFilter consultantFilter = null)
        {
            List<ConsultantDto> Consultants = this.BogDBContext.Consultant
                                              .ApplyFilterParameters(consultantFilter)
                                              .ApplyOrderParameters(orderBy)
                                              .TakePage(pageRequest, out pageResponse)
                                              .Select(x => x.ToConsultantDto()).ToList();
            return Consultants;
        }

        public IEnumerable<ConsultantDto> ReadWithSubConcultants(int consultantId)
        {
            List<ConsultantDto> Consultants = this.BogDBContext.Consultant.SelectWithSubConsultants(consultantId)
                .Select(x => x.ToConsultantDto()).ToList();

            return Consultants;
        }

        public int Update()
        {
            Consultant consultant = this.BogDBContext.Consultant.FirstOrDefault(x => x.Id == this.ConsultantDto.Id);
            if (consultant != null)
            {
                consultant.UpdateValues(this.ConsultantDto);
                this.BogDBContext.SaveChanges();
            }

            return consultant.Id;
        }

        public int Delete(int ConsultantId)
        {

            Consultant consultant = BogDBContext.Consultant.FirstOrDefault(x => x.Id == ConsultantId);
            BogDBContext.Consultant.Remove(consultant);

            return BogDBContext.SaveChanges();
        }

        public IValidateService ValidateCreation()
        {
            if (this.ConsultantDto == null)
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Consultant should be provided.";
                throw new BogApiException(null, ErrorModel);
            }

            if (BogDBContext.Consultant.Any(x => x.Code == this.ConsultantDto.Code))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Consultant code should be unique.";
                throw new BogApiException(null, ErrorModel);
            }

            if (this.ConsultantDto.RecommendatorId != null && this.ConsultantDto.RecommendatorId != 0 && !BogDBContext.Consultant.Any(x => x.Id == this.ConsultantDto.RecommendatorId.Value))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Consultant with the provided recommendatorId doesn't exists.";
                throw new BogApiException(null, ErrorModel);
            }


            return this;
        }

        public IValidateService ValidateUpdate()
        {
            if (this.ConsultantDto == null)
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Consultant should be provided.";
                throw new BogApiException(null, ErrorModel);
            }

            if (this.ConsultantDto.Id <= 0)
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Consultant Id is not valid.";
                throw new BogApiException(null, ErrorModel);
            }


            if (!BogDBContext.Consultant.Any(x => x.Id == this.ConsultantDto.Id))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Consultant doesn't exist.";
                throw new BogApiException(null, ErrorModel);
            }


            if (BogDBContext.Consultant.Any(x => x.Code == this.ConsultantDto.Code && x.Id != this.ConsultantDto.Id))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Consultant with the provided code already exists.";
                throw new BogApiException(null, ErrorModel);
            }

            if (this.ConsultantDto.RecommendatorId != null && !BogDBContext.Consultant.Any(x => x.Id == this.ConsultantDto.RecommendatorId.Value))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Consultant with the provided recommendatorId doesn't exists.";
                throw new BogApiException(null, ErrorModel);
            }


            if (BogDBContext.Consultant.SelectWithSubConsultants(this.ConsultantDto.Id).Any(x => x.Id == this.ConsultantDto.RecommendatorId))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "RecomendatorId is not valid. Hierarchy cycle error";
                throw new BogApiException(null, ErrorModel);
            }


            return this;
        }

        public IValidateService ValidateDelete(int id)
        {
            if (!BogDBContext.Consultant.Any(x => x.Id == id))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Consultant doesn't exist with the provided id.";
                throw new BogApiException(null, ErrorModel);
            }

            if (BogDBContext.Sale.Any(x => x.ConsultantId == id))
            {
                ErrorModel ErrorModel = new ErrorModel();
                ErrorModel.Message = "Consultant has sales. It is not allowed to delete.";
                throw new BogApiException(null, ErrorModel);
            }
            return this;
        }


    }
}
