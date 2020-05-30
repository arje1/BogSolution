using BogAPI.Models;
using BogAPI.Models.Filters;
using BogAPI.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Services.Interfaces
{
    public interface IConsultantService : IValidateService
    {
        IConsultantService InitializeConsultant(ConsultantDto consultantDto);
        int Create();
        IEnumerable<ConsultantDto> Read(PageRequest pageRequest, out PageResponse pageResponse, string orderBy = "", ConsultantFilter productFilter = null);
        IEnumerable<ConsultantDto> ReadWithSubConcultants(int consultantId);
        int Update();
        int Delete(int ConsultantId);
    }
}
