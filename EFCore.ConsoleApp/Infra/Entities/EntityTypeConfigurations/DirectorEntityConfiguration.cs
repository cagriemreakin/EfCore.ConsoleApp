using EFCore.Demo.Infra.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Demo.Infra.Entities.EntityTypeConfigurations;

public class DirectorEntityConfiguration : PersonBaseEntityTypeConfiguration<DirectorEntity>
{
    public override void Configure(EntityTypeBuilder<DirectorEntity> builder)
    {
        builder.ToTable("Directors");

        //Movies relation
        // builder.HasMany(i => i.Movies)
        //     .WithOne(i => i.Director)
        //     .HasForeignKey(i => i.DirectorId);
        base.Configure(builder);
    }
}