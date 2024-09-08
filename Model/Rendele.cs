using System;
using System.Collections.Generic;

namespace ITShop.Model;

public partial class Rendele
{
    public int IdRendeles { get; set; }

    public int IdUser { get; set; }

    public string Idsession { get; set; } = null!;

    public DateTime Datumido { get; set; }

    public string Fizmod { get; set; } = null!;

    public string Szallmod { get; set; } = null!;

    public string Allapot { get; set; } = null!;

    public string? Megjegyzes { get; set; }

    public virtual Userek IdUserNavigation { get; set; } = null!;

    public virtual ICollection<RendelesTetelei> RendelesTeteleis { get; set; } = new List<RendelesTetelei>();
}
