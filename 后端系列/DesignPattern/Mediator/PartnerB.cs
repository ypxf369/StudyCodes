using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator
{
    /// <summary>
    /// 具体用户类B
    /// </summary>
    public class PartnerB : IPartner
    {
        public int MoneyCount { get; set; }

        public void ChangeCount(int count, Mediator mediator)
        {
            mediator.BWin(count);
        }
    }
}
