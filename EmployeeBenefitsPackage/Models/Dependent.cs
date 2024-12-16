using Swashbuckle.AspNetCore.Annotations;

namespace EmployeeBenefitsPackage.Models;

public class Dependent
{
    [SwaggerSchema(ReadOnly = true)]
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string Name { get; set; }
}
