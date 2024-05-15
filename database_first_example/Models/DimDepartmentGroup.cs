using System;
using System.Collections.Generic;

namespace database_first_example.Models;

public partial class DimDepartmentGroup
{
    public int DepartmentGroupKey { get; set; }

    public int? ParentDepartmentGroupKey { get; set; }

    public string? DepartmentGroupName { get; set; }

    public virtual ICollection<DimDepartmentGroup> InverseParentDepartmentGroupKeyNavigation { get; set; } = new List<DimDepartmentGroup>();

    public virtual DimDepartmentGroup? ParentDepartmentGroupKeyNavigation { get; set; }
}
