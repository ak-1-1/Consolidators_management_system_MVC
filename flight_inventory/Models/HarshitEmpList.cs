﻿using System;
using System.Collections.Generic;

namespace flight_inventory.Models;

public partial class HarshitEmpList
{
    public int EId { get; set; }

    public string EName { get; set; } = null!;

    public string? EAdd { get; set; }

    public string EPhone { get; set; } = null!;

    public string EDesg { get; set; } = null!;

    public DateTime EDoj { get; set; }

    public virtual ICollection<HarshitEmpAbout> HarshitEmpAbouts { get; } = new List<HarshitEmpAbout>();
}
