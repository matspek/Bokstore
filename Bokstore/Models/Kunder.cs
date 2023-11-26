using System;
using System.Collections.Generic;

namespace Bokstore.Models;

public partial class Kunder
{
    public int KundId { get; set; }

    public string? Fornamn { get; set; }

    public string? Efternamn { get; set; }

    public string? Email { get; set; }
}
