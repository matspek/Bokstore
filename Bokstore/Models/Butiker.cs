using System;
using System.Collections.Generic;

namespace Bokstore.Models;

public partial class Butiker
{
    public int ButikerId { get; set; }

    public string? Butiksnamn { get; set; }

    public string? Addressuppgifter { get; set; }

    public virtual ICollection<LagerSaldo> LagerSaldos { get; set; } = new List<LagerSaldo>();
}
