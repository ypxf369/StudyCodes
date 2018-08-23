using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DotNetCore.CAP;
using Events;
using OrderService.Models.Databases;
using OrderService.Models.Entities;

namespace OrderService.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public OrderDbContext DbContext { get; set; }
        public ICapPublisher CapPublisher { get; set; }
        public string ConnStr { get; set; }

        public OrderRepository(OrderDbContext dbContext, ICapPublisher capPublisher, string connStr)
        {
            DbContext = dbContext;
            CapPublisher = capPublisher;
            ConnStr = connStr;
            //DbContext.Orders.ToList();
        }

        public async Task<bool> CreateOrderByDapperAsync(IOrder order)
        {
            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    string sql = @"INSERT INTO [dbo].[Orders](OrderID, OrderTime, OrderUserID, ProductID)
                                                                VALUES(@OrderID, @OrderTime, @OrderUserID, @ProductID)";
                    order.ID = Guid.NewGuid().ToString();
                    await conn.ExecuteAsync(sql, new
                    {
                        OrderId = order.ID,
                        OrderTime = DateTime.Now,
                        OrderUserID = order.OrderUserID,
                        ProductID = order.ProductID
                    }, trans);

                    var orderMessage = new OrderMessage()
                    {
                        ID = order.ID,
                        OrderUserID = order.OrderUserID,
                        OrderTime = order.OrderTime,
                        OrderItems = null,
                        MessageTime = DateTime.Now,
                        ProductID = order.ProductID
                    };
                    await CapPublisher.PublishAsync(EventConstants.EVENT_NAME_CREATE_ORDER, orderMessage, trans);

                    trans.Commit();
                }
            }
            return true;
        }

        public async Task<bool> CreateOrderByEfAsync(IOrder order)
        {
            using (var trans = DbContext.Database.BeginTransaction())
            {
                var orderEntity = new Order
                {
                    ID = Guid.NewGuid().ToString(),
                    OrderUserID = order.OrderUserID,
                    OrderTime = order.OrderTime,
                    OrderItems = null,
                    ProductID = order.ProductID
                };

                DbContext.Orders.Add(orderEntity);
                await DbContext.SaveChangesAsync();

                var orderMessage = new OrderMessage()
                {
                    ID = order.ID,
                    OrderUserID = order.OrderUserID,
                    OrderTime = order.OrderTime,
                    OrderItems = null,
                    MessageTime = DateTime.Now,
                    ProductID = order.ProductID
                };

                await CapPublisher.PublishAsync(EventConstants.EVENT_NAME_CREATE_ORDER, orderMessage);

                trans.Commit();
            }
            return true;
        }
    }
}
