﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Demo2OrderService.Service
{
    public class OrderService : IOrderService
    {
        private readonly ICapPublisher _publisher;
        private readonly OrderDbContext _dbContext;
        private readonly IHttpClientFactory _httpClient;

        public OrderService(OrderDbContext dbContext, ICapPublisher capPublisher, IHttpClientFactory httpClient)
        {
            _publisher = capPublisher;
            _dbContext = dbContext;
            _httpClient = httpClient;
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="productIds"></param>
        /// <returns></returns>
        public async Task<Guid> AddOrderAsync(Guid userId, IEnumerable<Guid> productIds)
        {
            //下单过程：
            //1.下单，写入订单表
            //2.用户支付，用户账户扣款
            //3.商品库存减一
            //4.企业账户加款
            if (userId == Guid.Empty || !productIds.Any())
            {
                throw new ArgumentException("参数为空");
            }
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                var client = _httpClient.CreateClient();
                string paramss = string.Join("|", productIds);
                //下单
                var order = new Order()
                {
                    UserId = userId,
                    TotalPrices = Convert.ToDecimal(await client.GetStringAsync("http://localhost:5001/api/Warehouse/getTotalPrice?productIds=" + paramss))//await _dbContext.Products.Where(i => productIds.Contains(i.Id)).SumAsync(i => i.Price)
                };
                await _dbContext.Orders.AddAsync(order);
                var orderProducts = productIds.Select(i => new OrderProduct()
                {
                    OrderId = order.Id,
                    ProductId = i
                });
                await _dbContext.OrderProducts.AddRangeAsync(orderProducts);

                await _dbContext.SaveChangesAsync();

                //发布消息
                await _publisher.PublishAsync(Constants.AddOrder, order);
                trans.Commit();
                return order.Id;
            }
        }
    }
}
