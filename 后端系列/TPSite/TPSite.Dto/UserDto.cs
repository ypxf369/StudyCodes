using System;
using System.Collections.Generic;
using System.Text;
using TPSite.Dto.Base;

namespace TPSite.Dto
{
    public class UserDto : EntityBaseFullDto<Guid>
    {
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Mobile { get; set; }
        public bool IsPhoneNumConfirmed { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public Guid? CreatorUserId { get; set; }
        public UserDto CreatorUser { get; set; }
        public Guid? DeleterUserId { get; set; }
        public UserDto DeleterUser { get; set; }
        public bool IsLocked { get; set; } = false;
    }
}
