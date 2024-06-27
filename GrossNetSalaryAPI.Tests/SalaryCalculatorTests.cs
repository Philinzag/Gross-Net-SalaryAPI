using GrossNetSalaryAPI.Models;
using GrossNetSalaryAPI.Services;
using Xunit;

namespace GrossNetSalaryAPI.Tests
{
    public class SalaryCalculatorTests
    {
        [Fact]
        public void CalculateGrossSalary_ReturnsCorrectGrossSalary()
        {
            var calculator = new SalaryCalculator();
            var request = new SalaryRequest
            {
                DesiredNetSalary = 1000,
                Allowances = 200
            };

            var result = calculator.CalculateGrossSalary(request);

            Assert.True(result.GrossSalary > request.DesiredNetSalary);
            Assert.Equal(request.Allowances, result.TotalAllowances);
        }
    }
}
