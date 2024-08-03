using System;
using System.Collections.Generic;

namespace LinqToDBBlog.Entities;

public partial class GnBolge
{
    public int IdBolge { get; set; }

    public string BolgeKodu { get; set; } = null!;

    public string BolgeAdi { get; set; } = null!;

    public string? FirmaAdi { get; set; }

    public string? FirmaKisaAdi { get; set; }

    public string? Vkn { get; set; }

    public string? EfaturaIban { get; set; }

    public virtual ICollection<AbAbone> AbAbone { get; set; } = new List<AbAbone>();
}
