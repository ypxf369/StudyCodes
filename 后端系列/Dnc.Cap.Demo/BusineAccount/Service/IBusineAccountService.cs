using System.Threading.Tasks;
using Entity;

namespace Demo2BusineAccount.Service
{
    public interface IBusineAccountService
    {
        Task InitDataAsync();
        Task AddBalanceAsync(PlaceOrderPushlishParams parameters);
    }
}
