using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Demo.Infra.Entities.EntityTypeConfigurations;

public class MovieEntityConfiguration : BaseEntityTypeConfiguration<MovieEntity>
{
    public override void Configure(EntityTypeBuilder<MovieEntity> builder)
    {
        builder.ToTable("Movies");
        builder.Property(i => i.Name)
            .HasColumnName("Name")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(i => i.ViewCount)
            .HasDefaultValue(1);


        //one2many director
        builder.HasOne(i => i.Director)
            .WithMany(i => i.Movies)
            .HasForeignKey(i => i.DirectorId);

        // one2many genre
        builder.HasOne(i => i.Genre)
            .WithMany(i => i.Movies)
            .HasForeignKey(i => i.GenreId);

        //many2many actors
        builder.HasMany(i => i.Actors)
            .WithMany(i => i.Movies)
            .UsingEntity(j => j.ToTable("MovieActors"));

        base.Configure(builder);
    }
}