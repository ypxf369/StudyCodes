using System.Threading.Tasks;

namespace Demo2BusineAccount.Service
{
    public interface IBusineAccountService
    {
        Task InitDataAsync();
        Task AddBalanceAsync(decimal amount);
    }
}
