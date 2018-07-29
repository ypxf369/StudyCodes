using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator
{
    /// <summary>
    /// 抽象中介者
    /// </summary>
    public abstract class Mediator
    {
        public PartnerA partnerA;
        public PartnerB partnerB;

        public Mediator(PartnerA partnerA, PartnerB partnerB)
        {
            this.partnerA = partnerA;
            this.partnerB = partnerB;
        }

        public abstract void AWin(int count);
        public abstract void BWin(int count);
    }
}
