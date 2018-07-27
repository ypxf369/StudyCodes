using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator
{
    /// <summary>
    /// 具体聚合角色
    /// </summary>
    public class ConcreteAggregate : IAggregate
    {
        private int[] collection;

        public ConcreteAggregate()
        {
            collection = new[] { 2, 3, 4, 5, 6, 8 };
        }

        public int Length => collection.Length;

        public int GetElement(int index)
        {
            return collection[index];
        }

        public ITerator GetITerator()
        {
            return new ConcreteIterator(this);
        }

    }
}
