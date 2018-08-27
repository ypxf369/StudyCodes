using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Demo2WarehouseService.Service
{
    public class ProductService : IProductService,ICapSubscribe
    {
        private readonly WarehouseDbContext _dbContext;
        public ProductService(WarehouseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitDataAsync()
        {
            var warehouse = new List<Warehouse>()
            {
                new Warehouse()
                {
                    Product = new Product
                    {
                        Name = "小米笔记本Pro",
                        Price = 6599
                    },
                    StoreNum = 10
                },
                new Warehouse()
                {
                    Product = new Product
                    {
                        Name = "三星S8",
                        Price = 4599
                    },
                    StoreNum = 8
                }
            };
            await _dbContext.AddRangeAsync(warehouse);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<decimal> CalcProductTotalPriceAsync(IEnumerable<Guid> productIds)
        {
            var totalPrice = await _dbContext.Products.Where(i => productIds.Contains(i.Id)).SumAsync(i => i.Price);
            return totalPrice;
        }

        /// <summary>
        /// 用户支付后，更新产品库存
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [CapSubscribe(Constants.UserPayment)]
        public async Task UpdateProductStoreNumAsync(PlaceOrderPushlishParams parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentException(nameof(parameters) + "为空");
            }
            var warehouses = await _dbContext.Warehouses.Where(i => parameters.ProductIds.Contains(i.ProductId))
                .ToListAsync();
            warehouses.ForEach(i => i.StoreNum--);
            await _dbContext.SaveChangesAsync();
        }
    }
}
