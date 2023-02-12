using TestTask_10._02._2023.Helpers;
using TestTask_10._02._2023.Models;
using TestTask_10._02._2023.Models.DTO;
using TestTask_10._02._2023.Models.VM;
using TestTask_10._02._2023.Repositories;

namespace TestTask_10._02._2023.Services
{
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// Defines the services.
        /// </summary>
        private readonly IEmployeeRepository employeeRepository;
        private readonly IPositionService positionService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="serviceProvider">Service Provider<see cref="IServiceProvider"/>.</param>
        public EmployeeService(IServiceProvider serviceProvider)
        {
            employeeRepository = serviceProvider.EmployeeRepository();
            positionService = serviceProvider.PositionService();
        }

        /// <summary>
        /// Get Employee By Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns><see cref="EmployeeDto"/>.</returns>
        public async Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await employeeRepository.GetEmployeeByIdAsync(employeeId);

            if (employee is null)
                throw new ArgumentException($"no Employee with id {employeeId}");

            return employee;
        }

        /// <summary>
        /// Create or Update Employee
        /// </summary>
        /// <param name="employeeVM"></param>
        /// <returns><see cref="EmployeeDto"/>.</returns>
        public async Task<EmployeeDto> CreateOrUpdateEmployeeAsync(EmployeeVM employeeVM)
        {
            var employeeDto = employeeVM.ToDto();
            var positions = new List<Position>();

            if (employeeVM.PositionsIds.Any())
            {
                positions = await positionService.GetPositionsListByIdAsync(employeeVM.PositionsIds);
            }

            if (await employeeRepository.GetEmployeeByIdAsync(employeeVM.Id) is null)
            {
                return await employeeRepository.CreateEmployeeAsync(employeeDto, positions);
            }
            else
            {
                return await employeeRepository.UpdateEmployeeAsync(employeeDto, positions);
            }
        }

        /// <summary>
        /// Delete Employee by Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task DeleteEmployeeByIdAsync(int employeeId)
        {
            await employeeRepository.DeleteEmployeeByIdAsync(employeeId);
        }
    }
}
