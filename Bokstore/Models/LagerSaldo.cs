using System;
using System.Collections.Generic;

namespace Bokstore.Models;

public partial class LagerSaldo
{
    public int LagerSaldoID { get; set; }

    public int? ButikId { get; set; }

    public string? Isbn { get; set; }

    public int? Antal { get; set; }

    public virtual Butiker? Butik { get; set; }

    public virtual Böcker? IsbnNavigation { get; set; }
}
