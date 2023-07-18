using EmployeeBenefitPackage.Models;
using EmployeeBenefitPackage.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBenefitPackage.Controllers
{
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
        public ActionResult<Dependent> AddDependent(Dependent dependent)
        {
            var dep = _dependentRepository.AddDependent(dependent);
            
            return dep;
        }
    }
}
