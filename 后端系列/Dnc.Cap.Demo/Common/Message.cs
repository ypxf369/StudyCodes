using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Message
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public object Content { get; set; }
        public string Creator { get; set; } = "yepeng";
        public DateTime CreateTime { get; set; } = DateTime.Now;
    }
}
