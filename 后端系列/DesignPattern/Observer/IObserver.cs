using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    /// <summary>
    /// 抽象观察者角色
    /// </summary>
    public interface IObserver
    {
        void ReciveAndPrint();
    }
}
