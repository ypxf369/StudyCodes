using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public bool PayStatus { get; set; } = false;
        public decimal TotalPrices { get; set; }
    }
}
