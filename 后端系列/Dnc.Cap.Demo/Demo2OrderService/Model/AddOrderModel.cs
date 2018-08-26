using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo2OrderService.Model
{
    public class AddOrderModel
    {
        public Guid UserId { get; set; }
        public IEnumerable<Guid> ProductIds { get; set; }
    }
}
