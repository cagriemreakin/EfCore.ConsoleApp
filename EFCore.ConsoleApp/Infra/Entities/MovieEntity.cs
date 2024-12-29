using EFCore.Demo.Infra.Entities.Base;
using EFDemo.Infra.Entities.Base;

namespace EFCore.Demo.Infra.Entities;

public class MovieEntity : BaseEntity
{
    public string Name { get; set; }
    public int ViewCount { get; set; }
    public Guid GenreId { get; set; }
    public Guid DirectorId { get; set; }


    public virtual GenreEntity Genre { get; set; }
    public virtual DirectorEntity Director { get; set; }
    public virtual ICollection<ActorEntity> Actors { get; set; }
}