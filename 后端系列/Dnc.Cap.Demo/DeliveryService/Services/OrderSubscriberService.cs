using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DotNetCore.CAP;
using Events;
using Newtonsoft.Json;

namespace DeliveryService.Services
{
    public class OrderSubscriberService : IOrderSubscriberService, ICapSubscribe
    {
        private readonly string _connStr;

        public OrderSubscriberService(string connStr)
        {
            _connStr = connStr;
        }
        [CapSubscribe(EventConstants.EVENT_NAME_CREATE_ORDER)]
        public async Task ConsumeOrderMessageAsync(OrderMessage message)
        {
            await Console.Out.WriteLineAsync(
                $"[DeliveryService] Received message : {JsonConvert.SerializeObject(message)}");
            await AddDeliveryRecordAsync(message);
        }

        private async Task<bool> AddDeliveryRecordAsync(OrderMessage order)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                string sql = @"INSERT INTO [dbo].[Deliveries] (DeliveryID, OrderID, ProductID, OrderUserID, CreatedTime)
                                                            VALUES (@DeliveryID, @OrderID, @ProductID, @OrderUserID, @CreatedTime)";
                int count = await conn.ExecuteAsync(sql, new
                {
                    DeliveryID = Guid.NewGuid().ToString(),
                    OrderID = order.ID,
                    OrderUserID = order.OrderUserID,
                    ProductID = order.ProductID,
                    CreatedTime = DateTime.Now
                });
                return count > 0;
            }
        }
    }
}
