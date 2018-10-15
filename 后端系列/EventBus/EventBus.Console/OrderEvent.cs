using System;
using System.Collections.Generic;
using System.Text;
using EventBus.Core;

namespace EventBus.Console
{
    /// <summary>
    /// 订单事件模型
    /// </summary>
    public class OrderEvent:IEvent
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        public Guid Id { get; set; }
    }
}
