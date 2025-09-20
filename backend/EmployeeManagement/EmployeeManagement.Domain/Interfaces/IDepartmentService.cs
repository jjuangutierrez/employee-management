using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<Department>> GetAllDepartmentsAsync();

    Task<Department> GetDepartmentAsync(int id);

    Task<Department> InsertDepartmentAsync(Department department);
    Task<Department> DeleteDepartmentAsync(int departmentId);
    Task UpdateDepartmentAsync(Department department);
}
