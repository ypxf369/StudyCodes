using System;
using System.IO;
using log4net;
using log4net.Config;
using Topshelf;

namespace Topshelf_Core
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
                    i.Service<MyService>(s =>
                    {
                        s.ConstructUsing(x => new MyService());
                        s.WhenStarted(x => x.Start());
                        s.WhenStopped(x => x.Stop());
                    });

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
            Console.ReadKey();
        }
    }
}
