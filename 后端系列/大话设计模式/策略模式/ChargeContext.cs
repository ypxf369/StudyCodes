using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 策略模式
{
    public class ChargeContext
    {
        private IChargeStrategy _chargeStrategy;

        public ChargeContext(string type)
        {
            switch (type)
            {
                case "正常收费":
                    _chargeStrategy = new Normal();
                    break;
                case "满300反100":
                    _chargeStrategy = new ManJian(300, 100);
                    break;
                case "打8折":
                    _chargeStrategy = new Discount(0.8);
                    break;
            }
        }

        public double GetTotalPrice(double money)
        {
            return _chargeStrategy.Calculate(money);
        }
    }
}
