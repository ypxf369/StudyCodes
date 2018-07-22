using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge
{
    /// <summary>
    /// 遥控器类
    /// </summary>
    public class RemoteControl
    {
        public TV TV { get; set; }

        public virtual void On()
        {
            TV.On();
        }

        public virtual void Off()
        {
            TV.Off();
        }

        public virtual void SwitchChannel()
        {
            TV.SwitchChannel();
        }
    }
}
