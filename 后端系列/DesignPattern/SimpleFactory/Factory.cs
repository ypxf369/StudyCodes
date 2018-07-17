using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleFactory
{
    /// <summary>
    /// 工厂类
    /// </summary>
    public class Factory
    {
        //缺点：每增加一种类型就要修改这里的代码
        public static BaseCustomer CreateCustomer(string type)
        {
            BaseCustomer baseCustomer = null;
            if (type.Equals(nameof(CustomerOne)))
            {
                baseCustomer = new CustomerOne();
            }
            else if (type.Equals(nameof(CustomerTwo)))
            {
                baseCustomer = new CustomerTwo();
            }
            return baseCustomer;
        }
    }
}
