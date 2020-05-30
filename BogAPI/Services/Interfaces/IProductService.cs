using BogAPI.Models;
using BogAPI.Models.Filters;
using BogAPI.Models.Paging;
using System.Collections.Generic;

namespace BogAPI.Services.Interfaces
{
    public interface IProductService : IValidateService
    {
        IProductService InitializeProduct(ProductDto productDto);
        int Create();
        IEnumerable<ProductDto> Read(PageRequest pageRequest, out PageResponse pageResponse, string orderBy = "", ProductFilter productFilter = null);
        int Update();
        void Delete(int ProductId);
    }
}
