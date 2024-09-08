using System;
using System.Collections.Generic;

namespace ITShop.Model;

public partial class Naplo
{
    public int IdNaplo { get; set; }

    public string User { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Sqlx { get; set; } = null!;

    public DateTime Datumido { get; set; }
}
