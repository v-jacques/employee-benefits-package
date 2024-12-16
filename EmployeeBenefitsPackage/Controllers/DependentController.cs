using EmployeeBenefitsPackage.Models;
using EmployeeBenefitsPackage.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBenefitsPackage.Controllers;

[ApiController]
[Route("[controller]")]
public class DependentController : Controller
{
    private readonly IDependentRepository _dependentRepository;

    public DependentController(IDependentRepository dependentRepository)
    {
        _dependentRepository = dependentRepository;
    }

    [HttpPost]
    public async Task<ActionResult<Dependent>> AddDependent(Dependent dependent)
    {
        var dep = await _dependentRepository.AddDependent(dependent);
        
        return dep;
    }
}
