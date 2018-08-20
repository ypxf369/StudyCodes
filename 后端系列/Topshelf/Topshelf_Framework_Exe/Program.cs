using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Topshelf_Framework_Exe
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
                    i.Service<MyService>();

                    i.RunAsLocalSystem();
                    i.SetDescription("Resharper License 服务");
                    i.SetServiceName("Resharper License");
                    i.SetDisplayName("Resharper License");
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
