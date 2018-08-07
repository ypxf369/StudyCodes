using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;
using Topshelf;

namespace Topshelf_Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);

            /*
             安装：TopshelfDemo.exe install
             启动：TopshelfDemo.exe start
             卸载：TopshelfDemo.exe uninstall
             */
            try
            {
                HostFactory.Run(i =>
                {
                    i.Service<MyService>();//用法1
                    i.Service<MyService1>(s =>
                    {
                        s.ConstructUsing(x => new MyService1());
                        s.WhenStarted(x => x.Start());
                        s.WhenStopped(x => x.Stop());
                    });//用法2

                    i.RunAsLocalSystem();
                    i.SetDescription("Topshelf测试服务");
                    i.SetServiceName("Topshelf");
                    i.SetDisplayName("TopshelfTest");
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
