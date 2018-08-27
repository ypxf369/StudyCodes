using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Entity;

namespace Demo2UserService.Service
{
    public class UserService : IUserService, ICapSubscribe
    {
        private readonly ICapPublisher _publisher;
        private readonly UserDbContext _dbContext;

        public UserService(ICapPublisher publisher, UserDbContext dbContext)
        {
            _publisher = publisher;
            _dbContext = dbContext;
        }
        public async Task<Guid> AddUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentException(nameof(user) + "为空");
            }
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user.Id;
        }

        /// <summary>
        /// 订阅下单消息，用户支付
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [CapSubscribe(Constants.AddOrder)]
        public async Task<Guid> UserPaymentAsync(PlaceOrderPushlishParams parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentException(nameof(parameters) + "为空");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                var user = await _dbContext.Users.FindAsync(parameters.UserId);
                user.Balance -= parameters.TotalPrice;
                await _dbContext.SaveChangesAsync();

                //发布消息，库存商品减1，企业账户加款
                await _publisher.PublishAsync(Constants.UserPayment, parameters);

                //支付成功，更新订单支付状态为“已支付”,通过mq回调方法
                return parameters.OrderId;
            }
        }
    }
}
