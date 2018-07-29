using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator
{
    /// <summary>
    /// 具体用户类A
    /// </summary>
    public class PartnerA : IPartner
    {
        public int MoneyCount { get; set; }

        public void ChangeCount(int count, Mediator mediator)
        {
            mediator.AWin(count);
        }
    }
}
