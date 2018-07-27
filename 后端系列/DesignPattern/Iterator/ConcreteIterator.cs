using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator
{
    /// <summary>
    /// 具体迭代器
    /// </summary>
    public class ConcreteIterator : ITerator
    {
        //迭代器需要对集合对象进行遍历操作，自然就需要引用集合对象
        private ConcreteAggregate _list;
        private int _index;

        public ConcreteIterator(ConcreteAggregate list)
        {
            _list = list;
            _index = 0;
        }
        public object GetCurrent()
        {
            return _list.GetElement(_index);
        }

        public bool MoveNext()
        {
            return _index < _list.Length;
        }

        public void Next()
        {
            if (_index < _list.Length)
            {
                _index++;
            }
        }

        public void Reset()
        {
            _index = 0;
        }
    }
}
