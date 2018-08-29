using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace Demo3Publish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ICapPublisher _publisher;
        private readonly PublishDbConext _dbConext;

        public ValuesController(ICapPublisher publisher, PublishDbConext dbConext)
        {
            _publisher = publisher;
            _dbConext = dbConext;
        }

        /*
         要想实现消息的发布与订阅，如果是RabbitMQ，发布者和订阅者必须在同一个Exchange中。
         */
        [HttpPost("publish")]
        public async Task<IActionResult> Publish(string message)
        {
            using (var trans = _dbConext.Database.BeginTransaction())
            {
                await _publisher.PublishAsync("cap.publish.msg.test", message);
                trans.Commit();
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
