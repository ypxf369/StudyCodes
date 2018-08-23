using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events;

namespace OrderService.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> CreateOrderByEfAsync(IOrder order);
        Task<bool> CreateOrderByDapperAsync(IOrder order);
    }
}
