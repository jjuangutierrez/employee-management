using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces;

public interface IDepartmentRepository : IDisposable
{
    Task<IEnumerable<Department>> GetAllDepartmentsAsync();
    Task<Department?> GetDepartmentAsync(int id);
    Task InsertDepartmentAsync(Department department);
    Task UpdateDepartmentAsync(Department department);
    Task DeleteDepartmentAsync(int departmentId);
}
