using System;
using System.Collections.Generic;

namespace Bokstore.Models;

public partial class Förlag
{
    public int FörlagId { get; set; }

    public string? Namn { get; set; }

    public string? Adess { get; set; }
}
