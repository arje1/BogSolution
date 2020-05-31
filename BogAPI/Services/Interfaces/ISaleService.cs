using BogAPI.Models;
using BogAPI.Models.Filters;
using BogAPI.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BogAPI.Services.Interfaces
{
    public interface ISaleService : IValidateService
    {
        ISaleService InitializeSale(SaleSaveDto saleDto);
        int Create();
        IEnumerable<SaleReadDto> Read(PageRequest pageRequest, out PageResponse pageResponse, string orderBy = "", SaleFilter saleFilter = null);
        int Update();
        int Delete(int SaleId);
    }
}
