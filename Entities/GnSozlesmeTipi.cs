using System;
using System.Collections.Generic;

namespace LinqToDBBlog.Entities;

public partial class GnSozlesmeTipi
{
    public int IdSozlesmeTipi { get; set; }

    public string SozlesmeTipiAdi { get; set; } = null!;

    public string SozlesmeTipiKodu { get; set; } = null!;

    public virtual ICollection<AbAbone> AbAbone { get; set; } = new List<AbAbone>();
}
