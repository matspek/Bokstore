using System;
using System.Collections.Generic;

namespace Bokstore.Models;

public partial class Ordrar
{
    public int OrderId { get; set; }

    public string? Isbn { get; set; }

    public int? Antal { get; set; }

    public virtual Böcker? IsbnNavigation { get; set; }
}
