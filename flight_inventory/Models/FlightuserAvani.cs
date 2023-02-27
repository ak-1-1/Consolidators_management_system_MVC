using System;
using System.Collections.Generic;

namespace flight_inventory.Models;

public partial class FlightuserAvani
{
    public int Userid { get; set; }

    public string? Username { get; set; }

    public string? Userpass { get; set; }

    public virtual ICollection<FlightbookingAvani> FlightbookingAvanis { get; } = new List<FlightbookingAvani>();
}
