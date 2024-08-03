using System;
using System.Collections.Generic;

namespace LinqToDBBlog.Entities;

public partial class DbRole
{
    public int IdRole { get; set; }

    public string RoleName { get; set; } = null!;

    public int? CreUser { get; set; }

    public DateTime CreDate { get; set; }

    public int? ModUser { get; set; }

    public DateTime? ModDate { get; set; }

    public string? Client { get; set; }

    public string? ClientIp { get; set; }

    public bool Deleted { get; set; }
}
