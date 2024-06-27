using GrossNetSalaryAPI.Models;
using GrossNetSalaryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GrossNetSalaryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController : ControllerBase
    {
        private readonly SalaryCalculator _calculator;

        public SalaryController()
        {
            _calculator = new SalaryCalculator();
        }

        [HttpPost]
        public ActionResult<SalaryDetails> CalculateGrossSalary([FromBody] SalaryRequest request)
        {
            var salaryDetails = _calculator.CalculateGrossSalary(request);
            return Ok(salaryDetails);
        }
    }
}
