using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Quartz;

namespace Topshelf_Core_Quartz
{
    public class MyServiceJob : IJob
    {
        private readonly ILog _log = LogManager.GetLogger("Topshelf_Core", typeof(MyServiceJob));
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                _log.Info($"{nameof(MyServiceJob)} is Executed\r\n");
                Console.WriteLine($"Quartz_当前时间: {DateTime.Now.ToLongTimeString()}");
            }
            catch (Exception e)
            {
                _log.Error(e.Message);
                Console.WriteLine(e);
            }
            return Task.CompletedTask;
        }
    }
}
