using System;
using EFDemo.Infra.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Demo.Infra.Entities.EntityTypeConfigurations;

public class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.CreatedDate)
            .HasColumnType("datetime2");
        // .HasDefaultValue(DateTime.Now)
        // .HasDefaultValueSql("getdate()") -> runs sql commands         
        builder.Property(e => e.ModifiedDate)
            .HasColumnType("datetime2")
            .IsRequired(false);
    }
}