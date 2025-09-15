using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Services;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee> GetEmployeeAsync(int employeId);
    Task<Employee> InsertEmployeeAsync(Employee employee);
    Task<Employee> DeleteEmployeeAsync(int employeeId);
    Task<Employee> UpdateEmployeeAsync(Employee employee);
}
