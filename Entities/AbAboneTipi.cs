using System;
using System.Collections.Generic;

namespace LinqToDBBlog.Entities;

public partial class AbAboneTipi
{
    public int IdAboneTipi { get; set; }

    public string AboneTipiAdi { get; set; } = null!;

    public int? IdAboneTipiGib { get; set; }

    public string SabitAl { get; set; } = null!;

    public bool SahaKontrol { get; set; }

    public bool ResmiDaire { get; set; }

    public int IdAboneSektor { get; set; }

    public virtual ICollection<AbAbone> AbAbone { get; set; } = new List<AbAbone>();
}
