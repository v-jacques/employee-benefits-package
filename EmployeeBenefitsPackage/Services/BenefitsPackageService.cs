using EmployeeBenefitsPackage.Models;

namespace EmployeeBenefitsPackage.Services;

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

    private static double CalculateBenefitsPackageCost(Employee employee)
    {
        const double baseEmployeeCost = 1000;
        const double baseDependentCost = 500;
        const double discount = 0.9;

        var dependentsCost = 0.0;

        foreach (var dependent in employee.Dependents)
            dependentsCost += HasNameDiscount(dependent.Name)
                ? baseDependentCost * discount
                : baseDependentCost;

        var employeeCost =
            HasNameDiscount(employee.Name)
                ? baseEmployeeCost * discount
                : baseEmployeeCost;

        return dependentsCost + employeeCost;
    }

    private static bool HasNameDiscount(string name)
    {
        return name.ToUpper().StartsWith('A');
    }
}
