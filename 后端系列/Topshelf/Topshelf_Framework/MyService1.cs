using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using log4net;

namespace Topshelf_Framework
{
    public class MyService1
    {
        private readonly Timer _timer;
        private readonly ILog _log = LogManager.GetLogger(typeof(MyService));

        public MyService1()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Console.WriteLine($"当前时间: {DateTime.Now.ToLongTimeString()}\r\n");
        }
        public bool Start()
        {
            try
            {
                _log.Info($"{nameof(MyService)} is started\r\n");
                _timer.Start();
                return true;
            }
            catch (Exception e)
            {
                _log.Error("服务启动失败：" + e.Message);
                if (e.InnerException != null)
                {
                    _log.Error(e.InnerException.Message);
                }
                return false;
            }
        }

        public bool Stop()
        {
            try
            {
                _log.Info($"{nameof(MyService)} is stoped\r\n");
                _timer.Stop();
                return true;
            }
            catch (Exception e)
            {
                _log.Error("服务停止失败：" + e.Message);
                if (e.InnerException != null)
                {
                    _log.Error(e.InnerException.Message);
                }
                return false;
            }
        }
    }
}
