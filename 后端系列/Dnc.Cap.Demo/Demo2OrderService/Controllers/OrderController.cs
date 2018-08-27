using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo2OrderService.Model;
using Demo2OrderService.Service;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo2OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("addOrder")]
        public async Task<IActionResult> AddOrder(AddOrderModel model)
        {
            await _orderService.AddOrderAsync(model.UserId, model.ProductIds);
            return Ok();
        }
    }
}