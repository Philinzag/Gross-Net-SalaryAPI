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
    // Define the tax brackets and rates
    var taxBrackets = new[]
    {
        new { MaxIncome = 490m, Rate = 0.05m },
        new { MaxIncome = 730m, Rate = 0.1m },
        new { MaxIncome = 3896.67m, Rate = 0.175m },
        new { MaxIncome = 19896.67m, Rate = 0.25m },
        new { MaxIncome = 50416.67m, Rate = 0.3m },
        new { MaxIncome = decimal.MaxValue, Rate = 0.35m }
    };

    decimal tax = 0m;
    decimal previousMaxIncome = 0m;

    foreach (var bracket in taxBrackets)
    {
        if (taxableIncome <= bracket.MaxIncome)
        {
            tax += (taxableIncome - previousMaxIncome) * bracket.Rate;
            break;
        }
        else
        {
            tax += (bracket.MaxIncome - previousMaxIncome) * bracket.Rate;
            previousMaxIncome = bracket.MaxIncome;
        }
    }

    return tax;
}

    }
}
