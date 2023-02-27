using System;
using System.Collections.Generic;

namespace flight_inventory.Models;

public partial class CourseArpit
{
    public int Cid { get; set; }

    public string? Cname { get; set; }

    public virtual ICollection<StudentArpit> StudentArpits { get; } = new List<StudentArpit>();
}
