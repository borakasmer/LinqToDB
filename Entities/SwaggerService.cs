using System;
using System.Collections.Generic;

namespace LinqToDBBlog.Entities;

public partial class SwaggerService
{
    public int Id { get; set; }

    public string ServiceKey { get; set; } = null!;

    public DateTime CreDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<UserSwagger> UserSwagger { get; set; } = new List<UserSwagger>();
}
