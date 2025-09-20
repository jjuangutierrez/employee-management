using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces;

public interface IDepartmentRepository
{
    Task<IEnumerable<Department>> GetAllDepartmentsAsync();

    Task<Department> GetDepartmentAsync(int id);

    Task<Department> InsertDepartmentAsync(Department department);
    Task DeleteDepartmentAsync(int departmentId);
    Task UpdateDepartmentAsync(Department department);
}
