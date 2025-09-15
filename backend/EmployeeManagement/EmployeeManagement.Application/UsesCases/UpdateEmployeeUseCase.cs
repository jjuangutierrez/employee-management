using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Services;

namespace EmployeeManagement.Application.UseCases;

public class UpdateEmployeeUseCase
{
    private readonly IEmployeeService _employeeService;

    public UpdateEmployeeUseCase(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<EmployeeDto?> ExecuteAsync(int id, UpdateEmployeeDto dto)
    {
        if (id <= 0)
            throw new ArgumentException("Employee ID must be greater than zero", nameof(id));

        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("Name is required", nameof(dto.Name));

        if (string.IsNullOrWhiteSpace(dto.LastName))
            throw new ArgumentException("LastName is required", nameof(dto.LastName));

        var employee = await _employeeService.GetEmployeeAsync(id);
        if (employee == null)
            return null;

        // Update employee properties
        employee.Name = dto.Name;
        employee.LastName = dto.LastName;
        employee.Age = dto.Age;
        employee.Email = dto.Email;
        employee.Phone = dto.Phone;
        employee.AlternatePhone = dto.AlternatePhone;
        employee.Salary = dto.Salary;
        employee.Position = dto.Position;
        employee.DepartmentId = dto.DepartmentId;
        employee.Role = dto.Role;
        employee.State = dto.State;

        var updatedEmployee = await _employeeService.UpdateEmployeeAsync(employee);
        return MapToEmployeeDto(updatedEmployee);
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