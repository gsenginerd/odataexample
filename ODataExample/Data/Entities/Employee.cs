using System;
using System.Collections.Generic;

namespace ODataExample.Data.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public decimal? Salary { get; set; }

    public string? JobRole { get; set; }

    public virtual EmployeeAddress? EmployeeAddress { get; set; }
}
