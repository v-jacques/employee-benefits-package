using EmployeeBenefitPackage.Models;
using EmployeeBenefitPackage.Repositories;
using EmployeeBenefitPackage.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBenefitPackage.Controllers
{
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
        public ActionResult<BenefitsPackage> GetBenefitPackage(int employeeId)
        {
            var employee = _employeeRepository.GetEmployee(employeeId);

            return _benefitsPackageService.CalculateBenefitsPackage(employee);
        }
    }
}
