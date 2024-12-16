using EmployeeBenefitsPackage.Models;
using EmployeeBenefitsPackage.Repositories;
using EmployeeBenefitsPackage.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBenefitsPackage.Controllers;

[ApiController]
[Route("[controller]")]
public class BenefitsPackageController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IBenefitsPackageService _benefitsPackageService;

    public BenefitsPackageController(IEmployeeRepository employeeRepository, IBenefitsPackageService benefitsPackageService)
    {
        _employeeRepository = employeeRepository;
        _benefitsPackageService = benefitsPackageService;
    }

    [HttpGet]
    public async Task<ActionResult<BenefitsPackage>> GetBenefitsPackage(int employeeId)
    {
        var employee = await _employeeRepository.GetEmployee(employeeId);

        return _benefitsPackageService.CalculateBenefitsPackage(employee);
    }
}
