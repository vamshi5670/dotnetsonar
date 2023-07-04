using System;
using System.Collections.Generic;

namespace TaskManagement.Models.DBModels;

public partial class EmpDetail
{
    public int EmpId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public int? DesgId { get; set; }

    public virtual EmpDesignation? Desg { get; set; }

    public virtual ICollection<TaskDetail> TaskDetails { get; } = new List<TaskDetail>();
}
