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
    public async Task<ActionResult<Employee>> AddEmployee([FromBody]Employee employee)
    {
        var emp = await _employeeRepository.AddEmployee(employee);

        return Ok(emp);
    }

    [HttpGet]
    public async Task<ActionResult<Employee>> GetEmployee([FromQuery]int id)
    {
        var employee = await _employeeRepository.GetEmployee(id);

        if (employee is null)
            return NotFound($"Employee with ID {id} not found.");

        return Ok(employee);
    }
}
