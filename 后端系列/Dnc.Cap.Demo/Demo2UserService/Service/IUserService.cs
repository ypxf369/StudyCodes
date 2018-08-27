using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace Demo2UserService.Service
{
    public interface IUserService
    {
        Task<Guid> AddUserAsync(User user);
        Task<Guid> UserPaymentAsync(PlaceOrderPushlishParams parameters);
    }
}
