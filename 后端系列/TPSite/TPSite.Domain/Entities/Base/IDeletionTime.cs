using System;

namespace TPSite.Domain.Entities.Base
{
    /// <summary>
    /// 定义删除时间标识
    /// </summary>
    public interface IDeletionTime
    {
        DateTime? DeletionTime { get; set; }
    }
}
