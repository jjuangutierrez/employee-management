using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces;

public interface IEmployeeRepository : IDisposable
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<Employee?> GetEmployeeAsync(int id);
    Task InsertEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(int employeeId);
    Task UpdateEmployeeAsync(Employee employee);
}
