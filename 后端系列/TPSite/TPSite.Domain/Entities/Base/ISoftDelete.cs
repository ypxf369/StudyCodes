namespace TPSite.Domain.Entities.Base
{
    /// <summary>
    /// 定义如软删除标识字段
    /// </summary>
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
