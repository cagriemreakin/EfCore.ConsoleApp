using EFCore.Demo.Infra.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Demo.Infra.Entities.EntityTypeConfigurations;

public class ActorEntityConfiguration : BaseEntityTypeConfiguration<ActorEntity>
{
    public override void Configure(EntityTypeBuilder<ActorEntity> builder)
    {
        builder.ToTable("Actors");
        builder.Property(i => i.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(i => i.LastName).HasMaxLength(100).IsRequired();
        //many2many
        // builder.ToTable(name:"Actors",schema:"ef");
        // builder.HasMany(i=>i.Movies)
        //     .WithMany(i=>i.Actors)
        //     .UsingEntity(j=>j.ToTable("ActorMovies"));
        base.Configure(builder);
    }
}