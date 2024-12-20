﻿using Swashbuckle.AspNetCore.Annotations;

namespace EmployeeBenefitsPackage.Models;

public class Employee : Person
{
    [SwaggerSchema(ReadOnly = true)]
    public ICollection<Dependent> Dependents { get; set; } = [];
}
