﻿using EmployeeBenefitsPackage.Models;
using EmployeeBenefitsPackage.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeBenefitsPackage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpPost]
        public ActionResult<Employee> AddEmployee(Employee employee)
        {
            var emp = _employeeRepository.AddEmployee(employee);

            return emp;
        }

        [HttpGet]
        public ActionResult<Employee> GetEmployee(int id)
        {
            return _employeeRepository.GetEmployee(id);
        }
    }
}
