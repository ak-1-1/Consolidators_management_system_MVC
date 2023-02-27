using System;
using System.Collections.Generic;

namespace flight_inventory.Models;

public partial class BrijeshBuyer
{
    public int BuyerId { get; set; }

    public string? BuyerName { get; set; }

    public string? BuyerPassword { get; set; }

    public virtual ICollection<BrijeshTran> BrijeshTrans { get; } = new List<BrijeshTran>();
}
