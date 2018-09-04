using System;

namespace TPSite.Domain.Entities.Base
{
    /// <summary>
    /// 定义创建时间标识
    /// </summary>
    public interface ICreationTime
    {
        DateTime CreationTime { get; set; }
    }
}
