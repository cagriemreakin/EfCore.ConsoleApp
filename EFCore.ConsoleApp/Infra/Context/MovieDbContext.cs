using Azure.Core;
using EFCore.Demo.Infra.Entities;
using EFCore.Demo.Infra.Entities.Base;
using EFCore.Demo.Infra.Entities.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EFCore.Demo.Infra.Context;

public class MovieDbContext : DbContext
{
    public MovieDbContext(DbContextOptions options) : base(options)
    {
    }

    public MovieDbContext()
    {
    }

    public DbSet<MovieEntity> Movies { get; set; }
    public DbSet<DirectorEntity> Directors { get; set; }
    public DbSet<GenreEntity> Genres { get; set; }
    public DbSet<ActorEntity> Actors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("ef");
        // select dll and apply configuration to all which are produced by IEntityTypeConfiguration
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieEntityConfiguration).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // if(optionsBuilder.IsConfigured)
        //     return;
        //
        // var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        // var connectionString = configuration.GetConnectionString("SqlServer");
        // optionsBuilder.UseSqlServer(connectionString, options =>
        // {
        //     options.CommandTimeout(5_000);
        //     options.EnableRetryOnFailure(maxRetryCount:5);
        //     
        // });
    }
}

public class DbContextFactory : IDesignTimeDbContextFactory<MovieDbContext>
{
    public MovieDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var connectionString = configuration.GetConnectionString("SqlServer");
        var optionsBuilder = new DbContextOptionsBuilder<MovieDbContext>();
        optionsBuilder.UseSqlServer(connectionString, options =>
        {
            options.MigrationsHistoryTable("__EFMigrationHistory", "ef");
            options.CommandTimeout(5_000);
            options.EnableRetryOnFailure(5);
        });
        return new MovieDbContext(optionsBuilder.Options);
    }
}