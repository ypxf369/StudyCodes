using System;
using System.Collections.Generic;
using System.Text;
using TPSite.Dto.Base;

namespace TPSite.Dto
{
    public class MessageRecordDto : EntityBaseFullDto<Guid>
    {
        public Guid FromUserId { get; set; }
        public UserDto FromUser { get; set; }
        public Guid ToUserId { get; set; }
        public UserDto ToUser { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
    }
}
