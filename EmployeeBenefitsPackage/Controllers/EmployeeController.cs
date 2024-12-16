using EmployeeBenefitsPackage.Models;
using EmployeeBenefitsPackage.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBenefitsPackage.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Employee>> AddEmployee(Employee employee)
    {
        var emp = await _employeeRepository.AddEmployee(employee);

        return emp;
    }

    [HttpGet]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        return await _employeeRepository.GetEmployee(id);
    }
}
