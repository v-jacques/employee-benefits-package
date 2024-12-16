using EmployeeBenefitsPackage.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBenefitsPackage.Repositories;

public interface IDependentRepository
{
    Task<Dependent> AddDependent(Dependent dependent);
    Task<IEnumerable<Dependent>> GetEmployeeDependents(Employee employee);
}

public class DependentRepository : IDependentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public DependentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Dependent> AddDependent(Dependent dependent)
    {
        var dep = await _dbContext.Dependents.AddAsync(dependent);
        await _dbContext.SaveChangesAsync();

        return dep.Entity;
    }

    public async Task<IEnumerable<Dependent>> GetEmployeeDependents(Employee employee)
    {
        return await _dbContext.Dependents
                               .Where(d => d.EmployeeId == employee.Id)
                               .ToListAsync();
    }
}
