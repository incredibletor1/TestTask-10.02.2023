using Microsoft.AspNetCore.Mvc;
using TestTask_10._02._2023.Helpers;
using TestTask_10._02._2023.Models.VM;
using TestTask_10._02._2023.Services;

namespace TestTask_10._02._2023.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// Defines the IEmployeeService
        /// </summary>
        private readonly IEmployeeService employeeService;

        /// <summary>
        /// Defines the logger
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="serviceProvider">Service Provider<see cref="IServiceProvider"/>.</param>
        /// <param name="logger">Logger<see cref="ILogger"/>.</param>
        public EmployeeController(IServiceProvider serviceProvider, ILogger<EmployeeController> logger)
        {
            employeeService = serviceProvider.EmployeeService();
            _logger = logger;
        }

        /// <summary>
        /// Get Employee By Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns><see cref="EmployeeVM"/>.</returns>
        [HttpGet]
        [Route("{employeeId}")]
        public async Task<IActionResult> GetEmployeeByIdAsync(int employeeId)
        {
            var employeeDto = await employeeService.GetEmployeeByIdAsync(employeeId);
            
            return Ok(employeeDto.ToVM());
        }

        /// <summary>
        /// Create or Update Employee
        /// </summary>
        /// <param name="employeeVM"></param>
        /// <returns><see cref="EmployeeVM"/>.</returns>
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateOrUpdateEmployeeAsync(EmployeeVM employeeVM)
        {
            var employeeDto = await employeeService.CreateOrUpdateEmployeeAsync(employeeVM);

            return Ok(employeeDto.ToVM());
        }

        /// <summary>
        /// Delete Employee by Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeByIdAsync(int employeeId)
        {
            await employeeService.DeleteEmployeeByIdAsync(employeeId);

            return Ok();
        }
    }
}
