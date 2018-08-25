using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Common;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CapService1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICapPublisher _publisher;
        private readonly Service1DbContext _dbContext;
        private readonly IConfiguration _configuration;

        public ValuesController(ICapPublisher publisher, Service1DbContext dbContext, IConfiguration configuration)
        {
            _publisher = publisher;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpPost("publishWithEf")]
        public async Task<IActionResult> PublishWithEntityFramework(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return BadRequest("消息为空");
            }
            var msg = new Message
            {
                Title = "测试消息",
                Content = message
            };
            await _publisher.PublishAsync("service1.publish.test", msg);
            //throw new Exception();//抛异常消息将继续发布到消息队列
            //事物提交之前的异常才会阻止消息的发送，事物之后不起作用
            return Ok();
        }

        [HttpPost("publishWithTransEf")]
        public async Task<IActionResult> PublishWithTransactionEntityFrameword(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return BadRequest("消息为空");
            }

            using (var trans = _dbContext.Database.BeginTransaction())
            {
                var msg = new Message
                {
                    Title = "测试下消息事物",
                    Content = message
                };
                await _publisher.PublishAsync("service1.publish.test.trans", msg, "CallBackMethodAsync");
                //throw new Exception();//启用事物，抛出异常后消息将不发送
                //事物提交之前的异常才会阻止消息的发送，事物之后不起作用
                trans.Commit();
            }
            return Ok();
        }

        [HttpPost("publishWithTransAdonet")]
        public async Task<IActionResult> PublishWithTransactionAdoNet(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                return BadRequest("消息为空");
            }
            using (var conn = new SqlConnection(_configuration["DB:ConnectionString"]))
            {
                conn.Open();
                using (var trans = conn.BeginTransaction())
                {
                    var msg = new Message
                    {
                        Title = "测试下消息AdoNet事物",
                        Content = message
                    };
                    await _publisher.PublishAsync("service1.publish.test.adonet.trans", msg, trans);
                    //throw new Exception();//启用事物，抛出异常后消息将不发送
                    //事物提交之前的异常才会阻止消息的发送，事物之后不起作用
                    trans.Commit();
                }
            }
            return Ok();
        }

        #region default
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion
    }
}
