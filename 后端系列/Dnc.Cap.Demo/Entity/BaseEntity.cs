using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Creator { get; set; } = "system";
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime? UpdateTime { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
