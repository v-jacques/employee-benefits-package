using EmployeeBenefitsPackage.Models;
using EmployeeBenefitsPackage.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBenefitsPackage.Controllers;

[ApiController]
[Route("[controller]")]
public class DependentController : ControllerBase
{
    private readonly IDependentRepository _dependentRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public DependentController(
        IDependentRepository dependentRepository,
        IEmployeeRepository employeeRepository)
    {
        _dependentRepository = dependentRepository;
        _employeeRepository = employeeRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Dependent>> AddDependent([FromBody]Dependent dependent)
    {
        var employee = await _employeeRepository.GetEmployee(dependent.EmployeeId);

        if (employee is null)
            return BadRequest($"Employee with ID {dependent.EmployeeId} not found.");

        var dep = await _dependentRepository.AddDependent(dependent);
        
        return Ok(dep);
    }
}
