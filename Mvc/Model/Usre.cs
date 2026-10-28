using System;
using System.Collections.Generic;

namespace WebApplication23.Models;

public partial class Usre
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string Email { get; set; } = null!;

    public int? Age { get; set; }

    public bool? Isactive { get; set; }

    public string? Imagepath { get; set; }

    public int? RolesId { get; set; }

    public virtual Role? Roles { get; set; }

    public virtual ICollection<Taske> Taskes { get; set; } = new List<Taske>();
}
