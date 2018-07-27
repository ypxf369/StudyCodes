using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator
{
    /// <summary>
    /// 聚合角色
    /// </summary>
    public interface IAggregate
    {
        ITerator GetITerator();
        int Length { get; }
        int GetElement(int index);
    }
}
