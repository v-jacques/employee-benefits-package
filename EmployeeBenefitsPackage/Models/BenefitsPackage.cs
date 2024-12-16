namespace EmployeeBenefitsPackage.Models;

public class BenefitsPackage
{
    public required Employee Employee { get; set; }
    public double TotalBenefitsCost { get; set; }
    public double Salary { get; set; }
    public double DiscountedSalary { get; set; }
    public double BasePaycheck { get; set; }
    public double DiscountedPaycheck { get; set; }
}
