using System;
using System.Collections.Generic;
using System.Text;

namespace 装饰者
{
    /// <summary>
    /// 服装装饰器
    /// </summary>
    public class FuZhuangDecorator : Person
    {
        private Person _person;
        public void DaBan(Person person)
        {
            _person = person;
        }
        public override void ChuanYi()
        {
            if (_person != null)
            {
                _person.ChuanYi();
            }
        }
    }
}
