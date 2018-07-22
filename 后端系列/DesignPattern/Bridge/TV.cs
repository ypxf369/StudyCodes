using System;
using System.Collections.Generic;
using System.Text;

namespace Bridge
{
    /// <summary>
    /// 抽象电视类，封装通用的抽象方法
    /// </summary>
    public abstract class TV
    {
        /// <summary>
        /// 开电视
        /// </summary>
        public abstract void On();

        /// <summary>
        /// 关电视
        /// </summary>
        public abstract void Off();

        /// <summary>
        /// 换台
        /// </summary>
        public abstract void SwitchChannel();
    }
}
