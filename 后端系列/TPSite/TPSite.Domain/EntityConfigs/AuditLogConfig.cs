using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPSite.Domain.Entities;
using TPSite.Tools.Extensions;

namespace TPSite.Domain.EntityConfigs
{
    public class AuditLogConfig : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.ToTable(nameof(AuditLog).ToPluralize()).HasQueryFilter(i => i.IsDeleted);
            builder.HasKey(i => i.Id);
            builder.Property(i => i.UserId);
            builder.Property(i => i.BrowserInfo).HasMaxLength(512);
            builder.Property(i => i.ServiceName).HasMaxLength(512);
            builder.Property(i => i.MethodName).HasMaxLength(512);
            builder.Property(i => i.Parameters).HasMaxLength(4096);
            builder.Property(i => i.ExecutionTime);
            builder.Property(i => i.ClientIpAddress).HasMaxLength(50);
        }
    }
}
