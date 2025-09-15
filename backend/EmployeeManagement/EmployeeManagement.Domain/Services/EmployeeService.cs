using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using System.Reflection.Metadata;

namespace EmployeeManagement.Domain.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync() => await _employeeRepository.GetAllEmployeesAsync();

    public async Task<Employee> GetEmployeeAsync(int employeId)
    {
        Employee employee = await _employeeRepository.GetEmployeeAsync(employeId);

        if (employee == null)
            throw new KeyNotFoundException($"Emplooye with ID:  {employeId} not found ");

        return employee;
    }

    public async Task<Employee> InsertEmployeeAsync(Employee employee)
    {
        if (employee.Salary < 1423500)
            throw new InvalidOperationException("The salary is below the minimum allowed");

        await _employeeRepository.InsertEmployeeAsync(employee);
        return employee;
    }

    public async Task<Employee> DeleteEmployeeAsync(int employeeId)
    {
        var existing = await _employeeRepository.GetEmployeeAsync(employeeId);
        if (existing == null)
            throw new KeyNotFoundException("Employee not found");

        await _employeeRepository.DeleteEmployeeAsync(employeeId);
        return existing;
    }

    public async Task<Employee> UpdateEmployeeAsync(Employee employee)
    {
        var existing = await _employeeRepository.GetEmployeeAsync(employee.Id);

        if (existing == null)
            throw new KeyNotFoundException("Employee not found");

        await _employeeRepository.UpdateEmployeeAsync(employee);
        return employee;
    }
}
