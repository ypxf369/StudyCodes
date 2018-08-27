using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    /// <summary>
    /// 用户下单MQ发布传递参数
    /// </summary>
    public class PlaceOrderPushlishParams
    {
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<Guid> ProductIds { get; set; }
    }
}
