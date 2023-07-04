using System;
using System.Collections.Generic;

namespace TaskManagement.Models.DBModels;

public partial class TaskDetail
{
    public int TaskId { get; set; }

    public string TaskDetails { get; set; } = null!;

    public string TaskDuration { get; set; } = null!;

    public DateTime AssignedDate { get; set; }

    public string Status { get; set; } = null!;

    public int? EmpId { get; set; }

    public virtual EmpDetail? Emp { get; set; }
}
