using TestTask_10._02._2023.Models.DTO;
using TestTask_10._02._2023.Models.VM;

namespace TestTask_10._02._2023.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetEmployeeByIdAsync(int employeeId);
        Task<EmployeeDto> CreateOrUpdateEmployeeAsync(EmployeeVM employeeVM);
        Task DeleteEmployeeByIdAsync(int employeeId);
    }
}
