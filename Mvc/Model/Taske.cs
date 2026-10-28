using System;
using System.Collections.Generic;

namespace WebApplication23.Models;

public partial class Taske
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Descriptions { get; set; }

    public int? UsersId { get; set; }

    public virtual Usre? Users { get; set; }
}
