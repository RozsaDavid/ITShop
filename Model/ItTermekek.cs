using System;
using System.Collections.Generic;

namespace ITShop.Model;

public partial class ItTermekek
{
    public int IdTermek { get; set; }

    public int IdKategoria { get; set; }

    public string Nev { get; set; } = null!;

    public string Azon { get; set; } = null!;

    public int Ar { get; set; }

    public int Mennyiseg { get; set; }

    public string Meegys { get; set; } = null!;

    /// <summary>
    /// forgalmazott termék?
    /// </summary>
    public string? Aktiv { get; set; }

    public string Termeklink { get; set; } = null!;

    public string Fotolink { get; set; } = null!;

    /// <summary>
    /// Megjegyzés
    /// </summary>
    public string? Leiras { get; set; }

    public DateTime Datumido { get; set; }

    public virtual ItKategoriak IdKategoriaNavigation { get; set; } = null!;

    public virtual ICollection<RendelesTetelei> RendelesTeteleis { get; set; } = new List<RendelesTetelei>();
}
