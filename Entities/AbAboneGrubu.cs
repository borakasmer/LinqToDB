using System;
using System.Collections.Generic;

namespace LinqToDBBlog.Entities;

public partial class AbAboneGrubu
{
    public int IdAboneGrubu { get; set; }

    public string AboneGrubuAdi { get; set; } = null!;

    public bool KismiOdemeYapabilir { get; set; }
}
