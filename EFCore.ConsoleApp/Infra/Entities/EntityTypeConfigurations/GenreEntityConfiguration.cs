using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Demo.Infra.Entities.EntityTypeConfigurations;

public class GenreEntityConfiguration : BaseEntityTypeConfiguration<GenreEntity>
{
    public override void Configure(EntityTypeBuilder<GenreEntity> builder)
    {
        builder.ToTable("Genres", "ef");
        builder.Property(i => i.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(100);
        base.Configure(builder);
    }
}