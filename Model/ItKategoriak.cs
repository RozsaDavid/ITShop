using System;
using System.Collections.Generic;

namespace ITShop.Model;

public partial class ItKategoriak
{
    public int IdKategoria { get; set; }

    public string Kategoria { get; set; } = null!;

    public virtual ICollection<ItTermekek> ItTermekeks { get; set; } = new List<ItTermekek>();
}
