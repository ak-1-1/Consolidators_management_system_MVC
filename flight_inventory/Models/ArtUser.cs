using System;
using System.Collections.Generic;

namespace flight_inventory.Models;

public partial class ArtUser
{
    public int Uid { get; set; }

    public string? Uname { get; set; }

    public string? Password { get; set; }
}
