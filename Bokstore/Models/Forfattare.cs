using System;
using System.Collections.Generic;

namespace Bokstore.Models;

public partial class Forfattare
{
    public int ForfattareId { get; set; }

    public string? Fornamn { get; set; }

    public string? Efternamn { get; set; }

    public DateTime? Fodelsedatum { get; set; }

    public virtual ICollection<Böcker> Böckers { get; set; } = new List<Böcker>();
}
