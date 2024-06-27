using GrossNetSalaryAPI.Models;

namespace GrossNetSalaryAPI.Services
{
    public class SalaryCalculator
    {
        private const decimal Tier1EmployerRate = 0.13m;
        private const decimal Tier2EmployeeRate = 0.055m;
        private const decimal Tier3EmployeeRate = 0.05m;
        private const decimal Tier3EmployerRate = 0.05m;

        public SalaryDetails CalculateGrossSalary(SalaryRequest request)
        {
            decimal grossSalary = request.DesiredNetSalary;
            decimal basicSalary = grossSalary - request.Allowances;
            decimal employeePensionContribution = CalculateEmployeePension(basicSalary);
            decimal taxableIncome = basicSalary - employeePensionContribution;
            decimal payeTax = CalculatePayeTax(taxableIncome);
            decimal netSalary = taxableIncome - payeTax;

            // Adjust gross salary until net salary matches the desired net salary
            while (netSalary < request.DesiredNetSalary)
            {
                grossSalary += 1;
                basicSalary = grossSalary - request.Allowances;
                employeePensionContribution = CalculateEmployeePension(basicSalary);
                taxableIncome = basicSalary - employeePensionContribution;
                payeTax = CalculatePayeTax(taxableIncome);
                netSalary = taxableIncome - payeTax;
            }

            return new SalaryDetails
            {
                GrossSalary = grossSalary,
                BasicSalary = basicSalary,
                TotalAllowances = request.Allowances,
                PayeTax = payeTax,
                EmployeePensionContribution = employeePensionContribution,
                EmployerPensionContribution = CalculateEmployerPension(basicSalary)
            };
        }

        private decimal CalculateEmployeePension(decimal basicSalary)
        {
            return (basicSalary * Tier2EmployeeRate) + (basicSalary * Tier3EmployeeRate);
        }

        private decimal CalculateEmployerPension(decimal basicSalary)
        {
            return (basicSalary * Tier1EmployerRate) + (basicSalary * Tier3EmployerRate);
        }

        private decimal CalculatePayeTax(decimal taxableIncome)
        {
            // Simplified PAYE tax calculation for demonstration
            if (taxableIncome <= 319)
                return taxableIncome * 0.05m;
            if (taxableIncome <= 419)
                return 15.95m + ((taxableIncome - 319) * 0.1m);
            if (taxableIncome <= 539)
                return 25.95m + ((taxableIncome - 419) * 0.175m);
            if (taxableIncome <= 3549)
                return 46.45m + ((taxableIncome - 539) * 0.25m);
            return 876.45m + ((taxableIncome - 3549) * 0.3m);
        }
    }
}
