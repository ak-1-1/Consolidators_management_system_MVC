using System;
using System.Collections.Generic;

namespace flight_inventory.Models;

public partial class FlightAvani
{
    public int FlightNo { get; set; }

    public DateTime? Departure { get; set; }

    public string? LeaveFrom { get; set; }

    public string? GoingTo { get; set; }

    public string? AirlinesName { get; set; }

    public string? Price { get; set; }

    public int? SeatsA { get; set; }

    public virtual ICollection<FlightbookingAvani> FlightbookingAvanis { get; } = new List<FlightbookingAvani>();
}
