using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo2WarehouseService.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo2WarehouseService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IProductService _productService;
        public WarehouseController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("initData")]
        public async Task InitData()
        {
            await _productService.InitDataAsync();
        }
        [HttpGet("getTotalPrice")]
        public async Task<decimal> GetProductsTotalPrice(string productIds)
        {
            var Ids = productIds.Split("|").Select(Guid.Parse);
            return await _productService.CalcProductTotalPriceAsync(Ids);
        }
    }
}