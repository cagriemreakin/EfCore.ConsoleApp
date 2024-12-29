using System;
using EFDemo.Infra.Entities.Base;

namespace EFCore.Demo.Infra.Entities.Base;

public class PersonBaseEntity : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}