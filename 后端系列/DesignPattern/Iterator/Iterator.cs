using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator
{
    /// <summary>
    /// 抽象迭代器角色，定义访问和遍历元素的接口
    /// </summary>
    public interface ITerator
    {
        bool MoveNext();
        object GetCurrent();
        void Next();
        void Reset();
    }
}
