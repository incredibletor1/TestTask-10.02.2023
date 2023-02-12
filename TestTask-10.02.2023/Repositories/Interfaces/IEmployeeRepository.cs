using TestTask_10._02._2023.Models;
using TestTask_10._02._2023.Models.DTO;

namespace TestTask_10._02._2023.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId);
        Task<EmployeeDto> CreateEmployeeAsync(EmployeeDto employeeDto, List<Position> positions);
        Task DeleteEmployeeByIdAsync(int employeeId);
        Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto employeeDto, List<Position> positions);
    }
}
