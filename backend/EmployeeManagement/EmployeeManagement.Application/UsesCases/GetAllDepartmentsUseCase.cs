using EmployeeManagement.Application.DTOs;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Services;

namespace EmployeeManagement.Application.UseCases;

public class GetAllDepartmentsUseCase
{
    private readonly IDepartmentService _departmentService;

    public GetAllDepartmentsUseCase(IDepartmentService departmentService) => _departmentService = departmentService;

    public async Task<IEnumerable<DepartmentDto>> ExecuteAsync()
    {
        var departments = await _departmentService.GetAllDepartmentsAsync();

        var result = new List<DepartmentDto>();

        foreach (var dept in departments)
        {
            var manager = dept.Employees?.FirstOrDefault(e => e.Id == dept.ManagerId);
            var managerName = manager != null ? $"{manager.Name} {manager.LastName}" : null;

            var employees = new List<EmployeeDto>();
            if (dept.Employees != null)
            {
                foreach (var emp in dept.Employees)
                {
                    employees.Add(new EmployeeDto
                    {
                        Id = emp.Id,
                        Name = emp.Name,
                        LastName = emp.LastName,
                        Age = emp.Age,
                        DocumentNumber = emp.DocumentNumber,
                        DocumentType = emp.DocumentType.ToString(),
                        HireDate = emp.HireDate,
                        Role = emp.Role.ToString(),
                        State = emp.State.ToString(),
                        Email = emp.Email,
                        Phone = emp.Phone,
                        AlternatePhone = emp.AlternatePhone,
                        Salary = emp.Salary,
                        Position = emp.Position,
                        DepartmentName = dept.Name
                    });
                }
            }

            result.Add(new DepartmentDto
            {
                Id = dept.Id,
                Name = dept.Name,
                Description = dept.Description,
                ManagerId = dept.ManagerId,
                Employees = employees
            });
        }

        return result;
    }
}