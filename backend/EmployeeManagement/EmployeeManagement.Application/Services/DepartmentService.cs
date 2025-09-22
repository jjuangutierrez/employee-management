using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IUserRepository _userRepository;

    public DepartmentService(IDepartmentRepository departmentRepository, IUserRepository userRepository)
    {
        _departmentRepository = departmentRepository;
        _userRepository = userRepository;
    }

    public async Task<Department> DeleteDepartmentAsync(int departmentId)
    {
        if (departmentId <= 0) throw new ArgumentException("Invalid department ID", nameof(departmentId));

        var department = await _departmentRepository.GetDepartmentAsync(departmentId);
        if (department == null)
            throw new KeyNotFoundException("Department not found");

        if (department.Users != null && department.Users.Any())
        {
            var usersToUpdate = department.Users.ToList();

            foreach (var user in usersToUpdate)
            {
                user.DepartmentId = null;
                await _userRepository.UpdateUserAsync(user);
            }
        }

        await _departmentRepository.DeleteDepartmentAsync(departmentId);
        return department;
    }

    public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
    {
        return await _departmentRepository.GetAllDepartmentsAsync();
    }

    public async Task<Department> GetDepartmentAsync(int id)
    {
        var department = await _departmentRepository.GetDepartmentAsync(id);
        if (department == null)
            throw new KeyNotFoundException($"Department: {id} not found");
        return department;
    }

    public async Task<Department> InsertDepartmentAsync(Department department)
    {
        if (department.ManagerId.HasValue)
        {
            var manager = await _userRepository.GetUserByIdAsync(department.ManagerId.Value);
            if (manager == null)
                throw new KeyNotFoundException("Manager not found");

            
        }

        var createdDepartment = await _departmentRepository.InsertDepartmentAsync(department);

        if (createdDepartment.ManagerId.HasValue)
        {
            await AssignManagerToDepartment(createdDepartment.Id, createdDepartment.ManagerId.Value);
        }

        return await _departmentRepository.GetDepartmentAsync(createdDepartment.Id);
    }

    public async Task UpdateDepartmentAsync(Department department)
    {
        var existingDepartment = await _departmentRepository.GetDepartmentAsync(department.Id);
        if (existingDepartment == null)
            throw new KeyNotFoundException("Department not found");

        if (department.ManagerId != existingDepartment.ManagerId)
        {
            if (existingDepartment.ManagerId.HasValue)
            {
                var oldManager = await _userRepository.GetUserByIdAsync(existingDepartment.ManagerId.Value);
                if (oldManager != null && oldManager.DepartmentId == department.Id)
                {
                    oldManager.DepartmentId = null;
                    await _userRepository.UpdateUserAsync(oldManager);
                }
            }

            if (department.ManagerId.HasValue)
            {
                await AssignManagerToDepartment(department.Id, department.ManagerId.Value);
            }
        }

        await _departmentRepository.UpdateDepartmentAsync(department);
    }

    private async Task AssignManagerToDepartment(int departmentId, int managerId)
    {
        var manager = await _userRepository.GetUserByIdAsync(managerId);
        if (manager == null)
            throw new KeyNotFoundException("Manager not found");

        manager.DepartmentId = departmentId;
        await _userRepository.UpdateUserAsync(manager);
    }
}