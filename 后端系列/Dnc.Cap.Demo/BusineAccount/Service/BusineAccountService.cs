using System;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Entity;
using Microsoft.EntityFrameworkCore;
using BusineAccount = Entity.BusineAccount;

namespace Demo2BusineAccount.Service
{
    public class BusineAccountService : IBusineAccountService, ICapSubscribe
    {
        private readonly ICapPublisher _publisher;
        private readonly BusineAccountDbContext _dbContext;

        public BusineAccountService(ICapPublisher publisher, BusineAccountDbContext dbContext)
        {
            _publisher = publisher;
            _dbContext = dbContext;
        }

        public async Task InitDataAsync()
        {
            var busineAccount = new Entity.BusineAccount
            {
                Balance = 0
            };
            await _dbContext.BusineAccounts.AddAsync(busineAccount);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 用户支付后企业账户加款
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        [CapSubscribe(Constants.UserPayment)]
        public async Task AddBalanceAsync(decimal amount)
        {
            if (amount == 0)
            {
                throw new ArgumentException(nameof(amount) + "为空");
            }
            var account = await _dbContext.BusineAccounts.FirstAsync();
            account.Balance += amount;
            await _dbContext.SaveChangesAsync();
        }
    }
}
