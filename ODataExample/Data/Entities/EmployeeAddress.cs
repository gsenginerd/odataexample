using System;
using System.Collections.Generic;

namespace ODataExample.Data.Entities;

public partial class EmployeeAddress
{
    public int Id { get; set; }

    public string? HouseNumber { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
