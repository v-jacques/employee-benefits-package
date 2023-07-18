namespace EmployeeBenefitPackage.Models
{
    public class BenefitsPackage
    {
        public Employee Employee { get; set; }
        public double TotalBenefitsCost { get; set; }
        public double Salary { get; set; }
        public double DiscountedSalary { get; set; }
        public double MonthlySalary { get; set; }
        public double MonthlyDiscountedSalary { get; set; }
    }
}
