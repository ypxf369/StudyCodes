using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class OrderProduct : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
    }
}
