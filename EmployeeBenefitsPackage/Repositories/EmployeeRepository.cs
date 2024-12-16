using EmployeeBenefitsPackage.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBenefitsPackage.Repositories;

public interface IEmployeeRepository
{
    Employee AddEmployee(Employee employee);
    Employee GetEmployee(int id);
}

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public EmployeeRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Employee AddEmployee(Employee employee)
    {
        var emp = _dbContext.Employees.Add(employee);
        _dbContext.SaveChanges();

        return emp.Entity;
    }

    public Employee GetEmployee(int employeeId)
    {
        return _dbContext.Employees.Include(e => e.Dependents).SingleOrDefault(e => e.Id == employeeId);
    }
}
