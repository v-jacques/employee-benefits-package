using Swashbuckle.AspNetCore.Annotations;

namespace EmployeeBenefitsPackage.Models;

public class Employee
{
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; set; }

    public required string Name { get; set; }

    [SwaggerSchema(ReadOnly = true)]
    public ICollection<Dependent> Dependents { get; set; } = [];
}
