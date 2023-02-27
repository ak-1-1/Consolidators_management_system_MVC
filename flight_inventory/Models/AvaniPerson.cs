using System;
using System.Collections.Generic;

namespace flight_inventory.Models;

public partial class AvaniPerson
{
    public int PersonId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }

    public virtual ICollection<AvaniOrder> AvaniOrders { get; } = new List<AvaniOrder>();
}
