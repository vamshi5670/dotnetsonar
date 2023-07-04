using System;
using System.Collections.Generic;

namespace TaskManagement.Models.DBModels;

public partial class EmpDesignation
{
    public int DesgId { get; set; }

    public string DesgName { get; set; } = null!;

    public virtual ICollection<EmpDetail> EmpDetails { get; } = new List<EmpDetail>();
}
