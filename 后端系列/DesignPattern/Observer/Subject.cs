using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    /// <summary>
    /// 订阅号，抽象主题角色
    /// </summary>
    public abstract class Subject
    {
        private readonly IList<IObserver> _observers = new List<IObserver>();

        //增加对订阅者的操作方法
        public void Add(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Remove(IObserver observer)
        {
            _observers.Remove(observer);
        }

        //对象变更之后通知所有的订阅者
        public void Update()
        {
            foreach (var obs in _observers)
            {
                obs?.ReciveAndPrint();
            }
        }
    }
}
