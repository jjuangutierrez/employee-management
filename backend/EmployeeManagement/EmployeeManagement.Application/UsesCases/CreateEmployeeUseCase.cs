using EmployeeManagement.Domain.Services;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Enums;
using EmployeeManagement.Application.DTOs;

namespace EmployeeManagement.Application.UseCases;

public class CreateEmployeeUseCase
{
    private readonly IEmployeeService _employeeService;

    public CreateEmployeeUseCase(IEmployeeService employeeService) => _employeeService = employeeService;

    public async Task<EmployeeDto> ExecuteAsync(CreateEmployeeDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("Name is required", nameof(dto.Name));

        if (string.IsNullOrWhiteSpace(dto.LastName))
            throw new ArgumentException("LastName is required", nameof(dto.LastName));

        if (string.IsNullOrWhiteSpace(dto.Email))
            throw new ArgumentException("Email is required", nameof(dto.Email));

        // Convert DTO to entity
        // Validación adicional para password
        if (string.IsNullOrWhiteSpace(dto.Password))
            throw new ArgumentException("Password is required", nameof(dto.Password));

        var employee = new Employee
        {
            Name = dto.Name,
            LastName = dto.LastName,
            Age = dto.Age,
            DocumentNumber = dto.DocumentNumber,
            DocumentType = dto.DocumentType,
            Email = dto.Email,
            Password = dto.Password,
            Phone = dto.Phone,
            AlternatePhone = dto.AlternatePhone,
            Salary = dto.Salary,
            Position = dto.Position,
            DepartmentId = dto.DepartmentId,
            Role = dto.Role,
            State = dto.State,
            HireDate = DateTime.UtcNow
        };


        var createdEmployee = await _employeeService.InsertEmployeeAsync(employee);

        // Convert Entity to output DTO
        return MapToEmployeeDto(createdEmployee);
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