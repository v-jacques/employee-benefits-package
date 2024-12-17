using EmployeeBenefitsPackage.Models;

namespace EmployeeBenefitsPackage.Services;

public interface IBenefitsPackageService
{
    BenefitsPackage CalculateBenefitsPackage(Employee employee);
}

public class BenefitsPackageService : IBenefitsPackageService
{
    public Func<Employee, double> EmployeeCostCalculator { get; set; }
    public Func<Dependent, double> DependentCostCalculator { get; set; }
    public Func<Person, bool> DiscountEligibilityChecker { get; set; }
    public Func<Person, double> DiscountValueProvider { get; set; }
    public Func<Employee, double> PaycheckValueProvider { get; set; }
    public Func<Employee, int> PaychecksPerYearProvider { get; set; }

    public BenefitsPackageService()
    {
        EmployeeCostCalculator = employee => 1000.0;
        DependentCostCalculator = dependent => 500.0;
        DiscountEligibilityChecker = person => person.Name.ToUpper().StartsWith('A');
        DiscountValueProvider = person => 0.9;
        PaycheckValueProvider = employee => 2000.0;
        PaychecksPerYearProvider = employee => 26;
    }

    public BenefitsPackage CalculateBenefitsPackage(Employee employee)
    {
        var paycheckValue = PaycheckValueProvider(employee);
        var paychecksPerYear = PaychecksPerYearProvider(employee);

        var dependentsCost = employee.Dependents.Sum(dependent =>
            DiscountEligibilityChecker(dependent)
                ? DependentCostCalculator(dependent) * DiscountValueProvider(dependent)
                : DependentCostCalculator(dependent));

        var employeeCost =
            DiscountEligibilityChecker(employee)
                ? EmployeeCostCalculator(employee) * DiscountValueProvider(employee)
                : EmployeeCostCalculator(employee);

        var totalBenefitsCost = dependentsCost + employeeCost;

        var baseSalary = paycheckValue * paychecksPerYear;
        var discountedSalary = baseSalary - totalBenefitsCost;
        var discountedPaycheck = discountedSalary / paychecksPerYear;

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
}
