using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using log4net;
using log4net.Core;

namespace Topshelf_Core
{
    public class MyService
    {
        private readonly Timer _timer;
        private readonly ILog _log = LogManager.GetLogger("Topshelf_Core", typeof(MyService));

        public MyService()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Console.WriteLine($"Core_当前时间: {DateTime.Now.ToLongTimeString()}");
        }

        public void Start()
        {
            try
            {
                _log.Info($"{nameof(MyService)} is started\r\n");
                _timer.Start();
            }
            catch (Exception e)
            {
                _log.Error("服务启动失败：" + e.Message);
                if (e.InnerException != null)
                {
                    _log.Error(e.InnerException.Message);
                }
            }
        }

        public void Stop()
        {
            try
            {
                _log.Info($"{nameof(MyService)} is stoped\r\n");
                _timer.Stop();
            }
            catch (Exception e)
            {
                _log.Error("服务停止失败：" + e.Message);
                if (e.InnerException != null)
                {
                    _log.Error(e.InnerException.Message);
                }
            }
        }
    }
}
