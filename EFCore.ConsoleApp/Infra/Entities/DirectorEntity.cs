namespace EFCore.Demo.Infra.Entities.Base;

public sealed class DirectorEntity : PersonBaseEntity
{
    public ICollection<MovieEntity> Movies { get; set; }
}