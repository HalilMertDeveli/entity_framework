using System;
using System.Collections.Generic;

namespace database_first_example.Models;

public partial class AdventureWorksDwbuildVersion
{
    public string? Dbversion { get; set; }

    public DateTime? VersionDate { get; set; }
}
