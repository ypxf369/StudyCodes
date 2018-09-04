using System;

namespace TPSite.Domain.Entities.Base
{
    public class EntityBaseFull<TPrimaryKey> : Entity<TPrimaryKey>, IFullEntity
    {
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime? LastModificationTime { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
