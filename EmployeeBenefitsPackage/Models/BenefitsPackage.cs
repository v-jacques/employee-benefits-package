namespace EmployeeBenefitPackage.Models
{
    public class BenefitsPackage
    {
        public Employee Employee { get; set; }
        public double TotalBenefitsCost { get; set; }
        public double Salary { get; set; }
        public double DiscountedSalary { get; set; }
        public double BasePaycheck { get; set; }
        public double DiscountedPaycheck { get; set; }
    }
}
