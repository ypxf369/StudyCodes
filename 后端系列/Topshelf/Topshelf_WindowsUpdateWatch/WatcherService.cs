using System;
using System.IO;
using System.Text;
using System.Timers;
using Topshelf;

namespace Topshelf_WindowsUpdateWatch
{
    public class WatcherService : ServiceControl
    {
        private readonly Timer _timer;
        private const string BasePath = @"C:\\Windows\\SoftwareDistribution\\Download";

        public WatcherService()
        {
            _timer = new Timer
            {
                //设置时间间隔
                Interval = 1800000,
                //设置单次执行（false）还是一直执行（true）
                AutoReset = true
            };
        }
        public bool Start(HostControl hostControl)
        {
            ////设置是否绑定事件
            _timer.Enabled = true;
            ////绑定事件
            _timer.Elapsed += DoWork;
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            try
            {
                hostControl.Stop();
            }
            finally
            {
                _timer.Stop();
            }
            return true;
        }

        private void DoWork(object sender, ElapsedEventArgs e)
        {
            DeleteFiles(BasePath);
        }

        private static void DeleteFiles(string path)
        {
            try
            {
                //启动时先检查文件夹下有没有文件，如果有直接删除
                DirectoryInfo dir = new DirectoryInfo(path);
                if (dir.Exists)
                {
                    foreach (var fileInfo in dir.GetFileSystemInfos())
                    {
                        if (fileInfo is DirectoryInfo)
                        {
                            Directory.Delete(fileInfo.FullName, true);
                        }
                        else
                        {
                            File.Delete(fileInfo.FullName);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e);
            }
        }
    }
}
