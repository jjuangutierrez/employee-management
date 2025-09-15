using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository) => _departmentRepository = departmentRepository;

    public async Task<IEnumerable<Department>> GetAllDepartmentsAsync() => await _departmentRepository.GetAllDepartmentsAsync();

    public async Task<Department> GetDepartmentAsync(int departmentId)
    {
        Department department = await _departmentRepository.GetDepartmentAsync(departmentId);

        if (department == null)
            throw new KeyNotFoundException($"Department with ID:  {departmentId} not found ");

        return department;
    }

    public async Task<Department> InsertDepartmentAsync(Department department)
    {
        await _departmentRepository.InsertDepartmentAsync(department);

        return department;
    }

    public async Task<Department> DeleteDepartmentAsync(int departmentId)
    {
        var existing = await _departmentRepository.GetDepartmentAsync(departmentId);

        if (existing == null)
            throw new KeyNotFoundException("Employee not found");

        await _departmentRepository.DeleteDepartmentAsync(departmentId);
        return existing;
    }

    public async Task<Department> UpdateDepartmentAsync(Department department)
    {
        var existing = await _departmentRepository.GetDepartmentAsync(department.Id);

        if (existing == null)
            throw new KeyNotFoundException("Employee not found");

        await _departmentRepository.UpdateDepartmentAsync(department);
        return department;
    }
}
