using Swashbuckle.AspNetCore.Annotations;

namespace EmployeeBenefitsPackage.Models
{
    public class Employee
    {
        [SwaggerSchema(ReadOnly = true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Dependent>? Dependents { get; set; }
    }
}
