using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator
{
    /// <summary>
    /// 抽象用户类
    /// </summary>
    public interface IPartner
    {
        int MoneyCount { get; set; }
        void ChangeCount(int count, Mediator mediator);
    }
}
