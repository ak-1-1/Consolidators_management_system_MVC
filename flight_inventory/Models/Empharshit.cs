using System;
using System.Collections.Generic;

namespace flight_inventory.Models;

public partial class Empharshit
{
    public int Eid { get; set; }

    public string? Ename { get; set; }

    public int? Salary { get; set; }

    public DateTime? Doj { get; set; }

    public string? City { get; set; }

    public virtual ICollection<EmpHarshitBranch> EmpHarshitBranches { get; } = new List<EmpHarshitBranch>();
}
