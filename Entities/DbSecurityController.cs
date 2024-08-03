using System;
using System.Collections.Generic;

namespace LinqToDBBlog.Entities;

public partial class DbSecurityController
{
    public int IdSecurityController { get; set; }

    public string? ControllerName { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CreUser { get; set; }

    public DateTime CreDate { get; set; }

    public int? ModUser { get; set; }

    public DateTime? ModDate { get; set; }

    public string? Client { get; set; }

    public string? ClientIp { get; set; }

    public bool Deleted { get; set; }

    public virtual ICollection<DbSecurityAction> DbSecurityAction { get; set; } = new List<DbSecurityAction>();

    public virtual ICollection<DbSecurityUserAction> DbSecurityUserAction { get; set; } = new List<DbSecurityUserAction>();

    public virtual ICollection<DbSecurityUserRole> DbSecurityUserRole { get; set; } = new List<DbSecurityUserRole>();
}
