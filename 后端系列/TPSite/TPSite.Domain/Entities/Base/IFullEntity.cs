namespace TPSite.Domain.Entities.Base
{
    /// <summary>
    /// 创建时间、修改时间、删除时间
    /// </summary>
    public interface IFullEntity : ICreationTime, IModificationTime, IDeletionTime
    {
    }
}
