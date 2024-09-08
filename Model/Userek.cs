using System;
using System.Collections.Generic;

namespace ITShop.Model;

public partial class Userek
{
    public int IdUser { get; set; }

    public string Nev { get; set; } = null!;

    public string Cim { get; set; } = null!;

    public string Telefon { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int Funkcio { get; set; }

    public virtual ICollection<Rendele> Rendeles { get; set; } = new List<Rendele>();
}
