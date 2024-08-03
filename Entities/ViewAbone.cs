using System;
using System.Collections.Generic;

namespace LinqToDBBlog.Entities;

public partial class ViewAbone
{
    public decimal AboneNo { get; set; }

    public decimal SozlesmeNo { get; set; }

    public bool MalSahibi { get; set; }

    public bool ResmiDaire { get; set; }

    public bool KismiOdemeYapabilir { get; set; }

    public string? FirmaKisaAdi { get; set; }

    public string SozlesmeTipiAdi { get; set; } = null!;
}
