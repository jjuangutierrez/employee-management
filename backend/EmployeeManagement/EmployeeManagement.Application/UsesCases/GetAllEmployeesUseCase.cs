using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Services;

namespace EmployeeManagement.Application.UseCases;

public class GetAllEmployeesUseCase
{
    private readonly IEmployeeService _employeeService;

    public GetAllEmployeesUseCase(IEmployeeService employeeService) => _employeeService = employeeService;

    public async Task<IEnumerable<EmployeeDto>> ExecuteAsync()
    {
        var employees = await _employeeService.GetAllEmployeesAsync();
        return employees.Select(MapToEmployeeDto);
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