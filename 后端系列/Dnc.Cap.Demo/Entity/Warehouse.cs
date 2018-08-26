using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Warehouse : BaseEntity
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int StoreNum { get; set; } = 0;
    }
}
