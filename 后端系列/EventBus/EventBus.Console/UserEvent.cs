using System;
using System.Collections.Generic;
using System.Text;
using EventBus.Core;

namespace EventBus.Console
{
    /// <summary>
    /// 用户事件模型
    /// </summary>
    public class UserEvent:IEvent
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public Guid Id { get; set; }
    }
}
