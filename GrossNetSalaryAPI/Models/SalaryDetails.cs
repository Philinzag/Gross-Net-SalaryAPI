namespace GrossNetSalaryAPI.Models
{
    public class SalaryDetails
    {
        public decimal GrossSalary { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal TotalAllowances { get; set; }
        public decimal PayeTax { get; set; }
        public decimal EmployeePensionContribution { get; set; }
        public decimal EmployerPensionContribution { get; set; }
    }
}
