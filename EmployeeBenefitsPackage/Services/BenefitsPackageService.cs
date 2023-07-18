using EmployeeBenefitPackage.Models;

namespace EmployeeBenefitPackage.Services
{
    public interface IBenefitsPackageService
    {
        BenefitsPackage CalculateBenefitsPackage(Employee employee);
    }

    public class BenefitsPackageService : IBenefitsPackageService
    {
        public BenefitsPackage CalculateBenefitsPackage(Employee employee)
        {
            const double paycheckValue = 2000;
            const int paychecksYear = 26;

            var totalBenefitsCost = CalculateBenefitsPackageCost(employee);

            var baseSalary = paycheckValue * paychecksYear;
            var discountedSalary = baseSalary - totalBenefitsCost;

            var discountedPaycheck = discountedSalary / paychecksYear;

            return new BenefitsPackage
            {
                Employee = employee,
                TotalBenefitsCost = totalBenefitsCost,
                Salary = baseSalary,
                DiscountedSalary = discountedSalary,
                BasePaycheck = paycheckValue,
                DiscountedPaycheck = discountedPaycheck
            };
        }

        private double CalculateBenefitsPackageCost(Employee employee)
        {
            const double baseEmployeeCost = 1000;
            const double baseDependentCost = 500;
            const double discount = 0.9;

            var dependentsCost = 0.0;
            if (employee.Dependents != null)
            {
                foreach (var dependent in employee.Dependents)
                {
                    if (HasNameDiscount(dependent.Name))
                        dependentsCost += baseDependentCost * discount;
                    else
                        dependentsCost += baseDependentCost;
                }
            }

            var employeeCost = HasNameDiscount(employee.Name) ? baseEmployeeCost * discount : baseEmployeeCost;

            var totalBenefitsCost = dependentsCost + employeeCost;

            return totalBenefitsCost;
        }

        private static bool HasNameDiscount(string name)
        {
            return name.ToUpper().StartsWith('A');
        }
    }
}
