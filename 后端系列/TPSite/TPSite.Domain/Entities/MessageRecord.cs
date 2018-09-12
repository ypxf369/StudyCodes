using System;
using System.Collections.Generic;
using System.Text;
using TPSite.Domain.Entities.Base;

namespace TPSite.Domain.Entities
{
    public class MessageRecord : EntityBaseFull<Guid>
    {
        public Guid FromUserId { get; set; }
        public User FromUser { get; set; }
        public Guid ToUserId { get; set; }
        public User ToUser { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
    }
}



