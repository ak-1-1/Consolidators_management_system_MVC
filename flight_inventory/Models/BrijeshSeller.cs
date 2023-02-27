﻿using System;
using System.Collections.Generic;

namespace flight_inventory.Models;

public partial class BrijeshSeller
{
    public int SellerId { get; set; }

    public string? SellerName { get; set; }

    public string? SellerPassword { get; set; }

    public virtual ICollection<BrijeshProperty> BrijeshProperties { get; } = new List<BrijeshProperty>();
}
