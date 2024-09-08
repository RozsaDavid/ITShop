using System;
using System.Collections.Generic;

namespace ITShop.Model;

public partial class RendelesTetelei
{
    public int IdRendtetel { get; set; }

    public int IdRendeles { get; set; }

    public int IdTermek { get; set; }

    public int Ar { get; set; }

    public int Mennyiseg { get; set; }

    public virtual Rendele IdRendelesNavigation { get; set; } = null!;

    public virtual ItTermekek IdTermekNavigation { get; set; } = null!;
}
