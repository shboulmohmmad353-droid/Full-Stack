using System;
using System.Collections.Generic;

namespace WebApplication23.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<Usre> Usres { get; set; } = new List<Usre>();
}
