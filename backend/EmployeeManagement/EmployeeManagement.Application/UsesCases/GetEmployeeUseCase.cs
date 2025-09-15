using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Services;

namespace EmployeeManagement.Application.UseCases;

public class GetEmployeeUseCase
{
    private readonly IEmployeeService _employeeService;

    public GetEmployeeUseCase(IEmployeeService employeeService) => _employeeService = employeeService;

    public async Task<EmployeeDto?> ExecuteAsync(int employeeId)
    {
        if (employeeId <= 0)
            throw new ArgumentException("Employee ID must be greater than zero", nameof(employeeId));

        var employee = await _employeeService.GetEmployeeAsync(employeeId);

        return employee == null ? null : MapToEmployeeDto(employee);
    }

    private static EmployeeDto MapToEmployeeDto(Employee employee)
    {
        return new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            LastName = employee.LastName,
            Age = employee.Age,
            DocumentNumber = employee.DocumentNumber,
            DocumentType = employee.DocumentType.ToString(),
            HireDate = employee.HireDate,
            Role = employee.Role.ToString(),
            State = employee.State.ToString(),
            Email = employee.Email,
            Phone = employee.Phone,
            AlternatePhone = employee.AlternatePhone,
            Salary = employee.Salary,
            Position = employee.Position,
            DepartmentName = employee.Department?.Name ?? string.Empty
        };
    }
}