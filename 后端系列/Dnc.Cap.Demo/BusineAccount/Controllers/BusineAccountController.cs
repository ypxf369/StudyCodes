using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo2BusineAccount.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo2BusineAccount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusineAccountController : ControllerBase
    {
        private readonly IBusineAccountService _busineAccountService;

        public BusineAccountController(IBusineAccountService busineAccountService)
        {
            _busineAccountService = busineAccountService;
        }

        [HttpGet("initData")]
        public async Task InitData()
        {
            await _busineAccountService.InitDataAsync();
        }
    }
}