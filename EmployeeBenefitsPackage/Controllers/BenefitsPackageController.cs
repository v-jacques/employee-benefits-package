using EmployeeBenefitsPackage.Models;
using EmployeeBenefitsPackage.Repositories;
using EmployeeBenefitsPackage.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBenefitsPackage.Controllers;

[ApiController]
[Route("[controller]")]
public class BenefitsPackageController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IBenefitsPackageService _benefitsPackageService;

    public BenefitsPackageController(
        IEmployeeRepository employeeRepository,
        IBenefitsPackageService benefitsPackageService)
    {
        _employeeRepository = employeeRepository;
        _benefitsPackageService = benefitsPackageService;
    }

    [HttpGet]
    public async Task<ActionResult<BenefitsPackage>> GetBenefitsPackage([FromQuery]int employeeId)
    {
        var employee = await _employeeRepository.GetEmployee(employeeId);

        if (employee is null)
            return NotFound($"Employee with ID {employeeId} not found.");

        var benefitsPackage = _benefitsPackageService.CalculateBenefitsPackage(employee);

        return Ok(benefitsPackage);
    }
}
