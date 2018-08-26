using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public decimal Balance { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}
