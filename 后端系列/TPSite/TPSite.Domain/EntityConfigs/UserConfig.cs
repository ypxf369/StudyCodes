using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TPSite.Domain.Entities;
using TPSite.Tools.Extensions;

namespace TPSite.Domain.EntityConfigs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User).ToPluralize()).HasQueryFilter(i => !i.IsDeleted);
            builder.HasKey(i => i.Id);
            builder.Property(i => i.UserName).HasMaxLength(50).IsRequired();
            builder.Property(i => i.RealName).HasMaxLength(50);
            builder.Property(i => i.Email).HasMaxLength(50);
            builder.Property(i => i.IsEmailConfirmed);
            builder.Property(i => i.Mobile).HasMaxLength(20);
            builder.Property(i => i.IsPhoneNumConfirmed);
            builder.Property(i => i.Password).HasMaxLength(100).IsRequired();
            builder.Property(i => i.Salt).HasMaxLength(50).IsRequired();
            builder.Property(i => i.IsDeleted).IsRequired();
            builder.Property(i => i.IsLocked).IsRequired();
            builder.Property(i => i.CreationTime);
            builder.Property(i => i.LastModificationTime);
            builder.Property(i => i.DeletionTime);
            builder.Property(i => i.CreatorUserId);
            builder.Property(i => i.DeleterUserId);
        }
    }
}
