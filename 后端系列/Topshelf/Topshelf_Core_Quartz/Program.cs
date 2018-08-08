using System;
using System.IO;
using log4net;
using log4net.Config;
using Topshelf;

namespace Topshelf_Core_Quartz
{
    class Program
    {
        static void Main(string[] args)
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(LogManager.CreateRepository("Topshelf_Core"), logCfg);

            try
            {
                HostFactory.Run(i =>
                {
                    i.Service<MyServiceRunner>(s =>
                    {
                        s.ConstructUsing(x => new MyServiceRunner());
                        s.WhenStarted(x => x.StartAsync().Wait());
                        s.WhenStopped(x => x.StopAsync().Wait());
                    });

                    i.SetDescription("Topshelf_Quartz测试服务");
                    i.SetServiceName("Topshelf_Quartz");
                    i.SetDisplayName("TopshelfTest_Quartz");
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}
