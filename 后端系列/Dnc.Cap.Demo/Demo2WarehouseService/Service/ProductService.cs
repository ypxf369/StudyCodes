using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Demo2WarehouseService.Service
{
    public class ProductService : IProductService
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
    }
}
