using System;
using System.Collections.Generic;

namespace LinqToDBBlog.Entities;

public partial class CompaniesInfo
{
    public int Id { get; set; }

    public long? CompanyNumber { get; set; }

    public string? CompanyName { get; set; }

    public string? ConnName { get; set; }

    public string? ConnStr { get; set; }

    public bool Deleted { get; set; }
}
