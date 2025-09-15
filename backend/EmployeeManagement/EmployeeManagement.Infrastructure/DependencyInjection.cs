using EmployeeManagement.Application.UseCases;
using EmployeeManagement.Application.UsesCases;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Domain.Services;
using EmployeeManagement.Infrastructure.Data;
using EmployeeManagement.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace EmployeeManagement.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureService(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");

        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

        // Register repositories
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();

        // Register services
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IDepartmentService, DepartmentService>();

        // Register use cases
        services.AddScoped<CreateEmployeeUseCase>();
        services.AddScoped<UpdateEmployeeUseCase>();
        services.AddScoped<DeleteEmployeeUseCase>();
        services.AddScoped<GetEmployeeUseCase>();
        services.AddScoped<GetAllEmployeesUseCase>();

        services.AddScoped<CreateDepartmentUseCase>();
        services.AddScoped<UpdateDepartmentUseCase>();
        services.AddScoped<DeleteDepartmentUseCase>();
        services.AddScoped<GetDepartmentUseCase>();
        services.AddScoped<GetAllDepartmentsUseCase>();

        return services;
    }
}
