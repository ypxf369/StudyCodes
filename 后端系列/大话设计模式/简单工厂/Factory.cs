using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 简单工厂
{
    public class Factory
    {
        public static Charge GetObj(string type)
        {
            switch (type)
            {
                case "正常收费":
                    return new Normal();
                case "满300反100":
                    return new ManJian(300, 100);
                case "打8折":
                    return new Discount(0.8);
                default:
                    return null;
            }
        }
    }
}
