using Swashbuckle.AspNetCore.Annotations;

namespace EmployeeBenefitsPackage.Models;

public class Person
{
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; set; }

    public required string Name { get; set; }
}
