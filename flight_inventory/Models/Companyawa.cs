using System;
using System.Collections.Generic;

namespace flight_inventory.Models;

public partial class Companyawa
{
    public string Cid { get; set; } = null!;

    public string? Cname { get; set; }

    public virtual ICollection<Flightawa> Flightawas { get; } = new List<Flightawa>();
}
