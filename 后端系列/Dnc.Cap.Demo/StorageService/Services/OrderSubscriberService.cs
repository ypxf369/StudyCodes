using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DotNetCore.CAP;
using Events;
using Newtonsoft.Json;

namespace StorageService.Services
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
                $"[StorageService] Received message : {JsonConvert.SerializeObject(message)}");
            await UpdateStorageNumberAsync(message);
        }

        private async Task<bool> UpdateStorageNumberAsync(OrderMessage order)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                string sql = @"UPDATE [dbo].[Storages] SET StorageNumber = StorageNumber - 1
                                                                WHERE StorageID = @ProductID";
                int count = await conn.ExecuteAsync(sql, new { ProductID = order.ProductID });
                return count > 0;
            }
        }
    }
}
