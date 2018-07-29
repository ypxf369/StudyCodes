using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator
{
    /// <summary>
    /// 具体中介者
    /// </summary>
    public class ConcreteMediator : Mediator
    {
        public ConcreteMediator(PartnerA partnerA, PartnerB partnerB) : base(partnerA, partnerB)
        {

        }
        public override void AWin(int count)
        {
            partnerA.MoneyCount += count;
            partnerB.MoneyCount -= count;
        }

        public override void BWin(int count)
        {
            partnerB.MoneyCount += count;
            partnerA.MoneyCount -= count;
        }
    }
}
