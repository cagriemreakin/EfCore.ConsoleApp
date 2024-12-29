using EFCore.Demo.Infra.Entities.Base;
using EFDemo.Infra.Entities.Base;

namespace EFCore.Demo.Infra.Entities;

public class GenreEntity : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<MovieEntity> Movies { get; set; }
}