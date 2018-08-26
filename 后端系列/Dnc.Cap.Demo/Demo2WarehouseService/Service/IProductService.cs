using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo2WarehouseService.Service
{
    public interface IProductService
    {
        Task InitDataAsync();
        Task<decimal> CalcProductTotalPriceAsync(IEnumerable<Guid> productIds);
    }
}
