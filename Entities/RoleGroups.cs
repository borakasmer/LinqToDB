using System;
using System.Collections.Generic;

namespace LinqToDBBlog.Entities;

public partial class RoleGroups
{
    public int Id { get; set; }

    public string? GroupName { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Roles> Roles { get; set; } = new List<Roles>();

    public virtual ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
}
