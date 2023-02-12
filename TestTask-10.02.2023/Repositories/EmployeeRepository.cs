using TestTask_10._02._2023.Models.DTO;
using TestTask_10._02._2023.Models;
using AutoMapper;
using TestTask_10._02._2023.Helpers;
using TestTask_10._02._2023.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace TestTask_10._02._2023.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        /// <summary>
        /// Defines DB context.
        /// </summary>
        private readonly ITestTaskDbContext _testTaskDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeRepository"/> class.
        /// </summary>
        /// <param name="testTaskDbContext">DB Context<see cref="ITestTaskDbContext"/>.</param>
        /// <param name="mapper">AutoMapper<see cref="IMapper"/>.</param>
        public EmployeeRepository(ITestTaskDbContext testTaskDbContext, IMapper mapper)
        {
            this._testTaskDbContext = testTaskDbContext;
            ConversionExtension.InitMapper(mapper);
        }

        /// <summary>
        /// Get Employee Entity By Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns><see cref="Employee"/>.</returns>
        private async Task<Employee> GetEmployeeEntityByIdAsync(int employeeId)
        {
            var employee = await _testTaskDbContext.Employees
                .Include(e => e.Positions)
                .FirstOrDefaultAsync(p => p.Id == employeeId);

            return employee;
        }

        /// <summary>
        /// Get Employee By Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns><see cref="EmployeeDto"/>.</returns>
        public async Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId)
        {
            var employee = await _testTaskDbContext.Employees
                .Include(e => e.Positions)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == employeeId);

            return employee.ToDto();
        }

        /// <summary>
        /// Create Employee
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <param name="positions">List on positions for current employee</param>
        /// <returns><see cref="EmployeeDto"/>.</returns>
        public async Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeDto, List<Position> positions)
        {
            var newEmployee = employeeDto.ToEntity();
            
            newEmployee.Positions = positions;
            
            var employee = await _testTaskDbContext.Employees.AddAsync(newEmployee);
            await _testTaskDbContext.SaveChangesAsync();

            return employee.Entity.ToDto();
        }

        /// <summary>
        /// Delete Employee By Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task DeleteEmployeeByIdAsync(int employeeId)
        {
            var employee = await GetEmployeeEntityByIdAsync(employeeId);

            if (employee is null)
                throw new ArgumentException($"no Employee with id {employeeId}");

            _testTaskDbContext.Employees.Remove(employee);
            await _testTaskDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Update Employee
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <param name="positions">List on positions for current employee</param>
        /// <returns><see cref="EmployeeDto"/>.</returns>
        public async Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto employeeDto, List<Position> positions)
        {
            var employee = await GetEmployeeEntityByIdAsync(employeeDto.Id);
            
            if (employee is null)
                throw new ArgumentException($"no Employee with id {employeeDto.Id}");

            employee.Positions.Clear();

            employee.FullName = employeeDto.FullName;
            employee.BirthDate = employeeDto.BirthDate;
            employee.Positions = positions;

            await _testTaskDbContext.SaveChangesAsync();

            return employee.ToDto();
        }
    }
}
