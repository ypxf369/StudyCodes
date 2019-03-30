using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Topshelf_WindowsUpdateWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             安装：TopshelfDemo.exe install
             启动：TopshelfDemo.exe start
             卸载：TopshelfDemo.exe uninstall
             */
            try
            {
                HostFactory.Run(i =>
                {
                    i.Service<WatcherService>();

                    i.RunAsLocalSystem();
                    i.SetDescription("Windows Update SoftwareDistribution/Download文件监听服务");
                    i.SetServiceName("Windows Update Watcher");
                    i.SetDisplayName("Windows Update Watcher");
                });
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
            }
        }
    }
}
