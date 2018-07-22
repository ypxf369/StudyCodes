using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator
{
    /// <summary>
    /// 抽象装饰者
    /// </summary>
    public abstract class Decorator : Phone
    {
        private readonly Phone _phone;

        public Decorator(Phone phone)
        {
            _phone = phone;
        }

        public override void Print()
        {
            _phone?.Print();
        }
    }
}
