using EmployeeBenefitsPackage.Models;

namespace EmployeeBenefitsPackage.Repositories
{
    public interface IDependentRepository
    {
        Dependent AddDependent(Dependent dependent);
        IEnumerable<Dependent> GetDependentsFromEmployee(Employee employee);
    }

    public class DependentRepository : IDependentRepository
    {
        private readonly ApplicationDbContext _context;

        public DependentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Dependent AddDependent(Dependent dependent)
        {
            var dep = _context.Dependents.Add(dependent);
            _context.SaveChanges();

            return dep.Entity;
        }

        public IEnumerable<Dependent> GetDependentsFromEmployee(Employee employee)
        {
            return _context.Dependents.Where(d => d.EmployeeId == employee.Id);
        }
    }
}
