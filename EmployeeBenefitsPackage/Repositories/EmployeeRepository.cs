using EmployeeBenefitsPackage.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBenefitsPackage.Repositories;

public interface IEmployeeRepository
{
    Task<Employee> AddEmployee(Employee employee);
    Task<Employee> GetEmployee(int id);
}

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public EmployeeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Employee> AddEmployee(Employee employee)
    {
        var emp = await _dbContext.Employees.AddAsync(employee);
        await _dbContext.SaveChangesAsync();

        return emp.Entity;
    }

    public async Task<Employee> GetEmployee(int employeeId)
    {
        return await _dbContext.Employees
                               .Include(e => e.Dependents)
                               .SingleAsync(e => e.Id == employeeId);
    }
}
