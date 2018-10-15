using System;
using System.Collections.Generic;
using System.Text;
using TPSite.Domain.Entities.Base;

namespace TPSite.Domain.Entities
{
    public class User : EntityBaseFull<Guid>
    {
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        public string Mobile { get; set; }
        public bool IsPhoneNumConfirmed { get; set; } = false;
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Avatar { get; set; }
        public Guid? CreatorUserId { get; set; }
        public virtual User CreatorUser { get; set; }
        public Guid? DeleterUserId { get; set; }
        public virtual User DeleterUser { get; set; }
        public bool IsLocked { get; set; } = false;
    }
}
