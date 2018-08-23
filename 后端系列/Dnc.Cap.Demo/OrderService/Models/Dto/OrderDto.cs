using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Events;

namespace OrderService.Models.Dto
{
    public class OrderDto:IOrder
    {
        public string ID { get; set; }

        public DateTime OrderTime { get; set; }

        public List<IOrderItems> OrderItems { get; set; }

        public string OrderUserID { get; set; }

        //public string StatusKey { get; set; }

        public string ProductID { get; set; }
    }
}
