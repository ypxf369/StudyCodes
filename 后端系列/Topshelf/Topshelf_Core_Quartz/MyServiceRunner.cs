using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Quartz;
using Quartz.Impl;

namespace Topshelf_Core_Quartz
{
    public class MyServiceRunner
    {
        private readonly IScheduler _scheduler;
        private readonly ILog _log = LogManager.GetLogger(typeof(MyServiceRunner));

        public MyServiceRunner()
        {
            _scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
        }

        public async Task StartAsync()
        {
            try
            {
                _log.Info($"{nameof(MyServiceRunner)} is creating\r\n");
                JobKey jobKey = new JobKey(nameof(MyServiceJob));
                IJobDetail job = JobBuilder.Create(typeof(MyServiceJob))
                    .WithIdentity(jobKey)
                    .Build();

                CronScheduleBuilder scheduleBuilder = CronScheduleBuilder.CronSchedule("0/1 * * * * ?");

                ITrigger trigger = TriggerBuilder.Create().StartNow()
                    .WithIdentity(nameof(MyServiceJob) + "_Trigger")
                    .ForJob(jobKey)
                    .WithSchedule(scheduleBuilder.WithMisfireHandlingInstructionDoNothing())
                    .Build();
                await _scheduler.ScheduleJob(job, trigger);
                _log.Info($"{nameof(MyServiceRunner)} is created\r\n");
                await _scheduler.Start();
                _log.Info($"{nameof(MyServiceRunner)} is started\r\n");
            }
            catch (Exception e)
            {
                _log.Error(e.Message);
                Console.WriteLine(e);
            }
        }

        public async Task StopAsync()
        {
            try
            {
                await _scheduler.PauseJob(new JobKey(nameof(MyServiceJob)));
            }
            catch (Exception e)
            {
                _log.Error(e.Message);
                Console.WriteLine(e);
            }
        }
    }
}
