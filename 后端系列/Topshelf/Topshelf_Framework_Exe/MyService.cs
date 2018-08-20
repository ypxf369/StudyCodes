using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Topshelf_Framework_Exe
{
    public class MyService : ServiceControl
    {
        private readonly Process _process;

        public MyService()
        {
            _process = new Process();
        }
        public bool Start(HostControl hostControl)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;// 当前运行程序的根路径
                _process.StartInfo.FileName = path + "IntelliJIDEALicenseServer_windows_amd64.exe";
                _process.StartInfo.WorkingDirectory = path;
                _process.StartInfo.CreateNoWindow = true;//不在新窗口打开
                _process.Start();

            }
            catch (Exception e)
            {

            }
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            try
            {
                _process.Kill();
            }
            catch (Exception e)
            {

            }
            return true;
        }
    }
}
