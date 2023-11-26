using System;
using System.Collections.Generic;

namespace Bokstore.Models;

public partial class Böcker
{
    public string Isbn { get; set; } = null!;

    public string? Titel { get; set; }

    public string? Sprak { get; set; }

    public decimal? Pris { get; set; }

    public DateTime? Utgivningsdatum { get; set; }

    public int? ForfattarId { get; set; }

    public virtual Forfattare? Forfattar { get; set; }

    public virtual ICollection<LagerSaldo> LagerSaldos { get; set; } = new List<LagerSaldo>();

    public virtual ICollection<Ordrar> Ordrars { get; set; } = new List<Ordrar>();

    public override string ToString()
    {
        return Titel;
    }
}
