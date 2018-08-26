using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace Demo2OrderService.Service
{
    public interface IOrderService
    {
        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productIds"></param>
        /// <returns></returns>
        Task<Guid> AddOrderAsync(Guid userId,IEnumerable<Guid> productIds);
    }
}
