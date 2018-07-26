using System;
using System.Collections.Generic;
using System.Text;

namespace Template
{
    /// <summary>
    /// 蔬菜，抽象模板角色
    /// </summary>
    public abstract class Vegetabel
    {
        /// <summary>
        /// 做菜：不要声明成abstract或virtual，避免在子类中重写改变原有的流程
        /// </summary>
        public void CookVegetable()
        {
            DaoYou();//倒油
            JiaRe();//加热
            AddVegetabel();//加入蔬菜
            ChaoCai();//炒菜
        }

        public void DaoYou()
        {
            Console.WriteLine("向锅中倒油。。。");
        }

        public void JiaRe()
        {
            Console.WriteLine("将锅中的油加热。。。");
        }

        public abstract void AddVegetabel();

        public void ChaoCai()
        {
            Console.WriteLine("将锅中的蔬菜进行翻炒。。。");
        }
    }
}
