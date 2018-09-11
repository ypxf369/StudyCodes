using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPSite.Domain.Entities;
using TPSite.Tools.Extensions;

namespace TPSite.Domain.EntityConfigs
{
    public class MessageRecordConfig : IEntityTypeConfiguration<MessageRecord>
    {
        public void Configure(EntityTypeBuilder<MessageRecord> builder)
        {
            builder.ToTable(nameof(MessageRecord).ToPluralize()).HasQueryFilter(i => !i.IsDeleted);
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Message).HasMaxLength(4000).IsRequired();
            builder.Property(i => i.IsRead).IsRequired();
            builder.Property(i => i.FromUserId).IsRequired();
            builder.Property(i => i.ToUserId).IsRequired();
            builder.Property(i => i.IsDeleted).IsRequired();
            builder.Property(i => i.CreationTime);
            builder.Property(i => i.LastModificationTime);
            builder.Property(i => i.DeletionTime);
        }
    }
}
