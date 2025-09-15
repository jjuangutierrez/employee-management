using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Services;

public interface IDepartmentService
{
    Task<IEnumerable<Department>> GetAllDepartmentsAsync();
    Task<Department> GetDepartmentAsync(int departmentId);
    Task<Department> InsertDepartmentAsync(Department department);
    Task<Department> DeleteDepartmentAsync(int departmentId);
    Task<Department> UpdateDepartmentAsync(Department department);
}
