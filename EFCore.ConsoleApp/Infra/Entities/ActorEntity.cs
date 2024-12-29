namespace EFCore.Demo.Infra.Entities.Base;

public class ActorEntity : PersonBaseEntity
{
    public virtual ICollection<MovieEntity> Movies { get; set; }
}