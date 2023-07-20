using EmployeeBenefitsPackage.Models;
using EmployeeBenefitsPackage.Services;
using Xunit;

namespace EmployeeBenefitsPackage.Test
{
    public class BenefitsPackageTest
    {
        private readonly BenefitsPackageService _benefitsPackageService;

        public BenefitsPackageTest()
        {
            _benefitsPackageService = new BenefitsPackageService();
        }

        [Fact]
        public void CalculateBenefitsPackage_EmployeeWithNoDependents()
        {
            var employee = new Employee
            {
                Name = "Vinicius",
            };

            var benefitsCost = _benefitsPackageService.CalculateBenefitsPackage(employee);

            Assert.Equal(1000.0, benefitsCost.TotalBenefitsCost);
            Assert.Equal(52000.0, benefitsCost.Salary);
            Assert.Equal(51000.0, benefitsCost.DiscountedSalary);
            Assert.Equal(2000.0, benefitsCost.BasePaycheck);
            Assert.Equal(1961.5384615384614, benefitsCost.DiscountedPaycheck);
        }

        [Fact]
        public void CalculateBenefitsPackage_EmployeeWithDependent()
        {
            var dependent = new Dependent
            {
                Name = "Jacques"
            };

            var employee = new Employee
            {
                Name = "Vinicius",
                Dependents = new List<Dependent> { dependent }
            };

            var benefitsCost = _benefitsPackageService.CalculateBenefitsPackage(employee);

            Assert.Equal(1500.0, benefitsCost.TotalBenefitsCost);
            Assert.Equal(52000.0, benefitsCost.Salary);
            Assert.Equal(50500.0, benefitsCost.DiscountedSalary);
            Assert.Equal(2000.0, benefitsCost.BasePaycheck);
            Assert.Equal(1942.3076923076924, benefitsCost.DiscountedPaycheck);
        }

        [Fact]
        public void CalculateBenefitsPackage_EmployeeWithDependentAndDiscounts()
        {
            var dependent = new Dependent
            {
                Name = "AJacques"
            };

            var employee = new Employee
            {
                Name = "AVinicius",
                Dependents = new List<Dependent> { dependent }
            };

            var benefitsCost = _benefitsPackageService.CalculateBenefitsPackage(employee);

            Assert.Equal(1350.0, benefitsCost.TotalBenefitsCost);
            Assert.Equal(52000.0, benefitsCost.Salary);
            Assert.Equal(50650.0, benefitsCost.DiscountedSalary);
            Assert.Equal(2000.0, benefitsCost.BasePaycheck);
            Assert.Equal(1948.0769230769231, benefitsCost.DiscountedPaycheck);
        }
    }
}