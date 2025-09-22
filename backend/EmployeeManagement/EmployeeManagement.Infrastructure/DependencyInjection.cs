using EmployeeManagement.Application.DTOs.Announcement;
using EmployeeManagement.Application.DTOs.Departments;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Application.UseCases.Announcement;
using EmployeeManagement.Application.UseCases.Users;
using EmployeeManagement.Application.UsesCases.Departments;
using EmployeeManagement.Application.UsesCases.Tasks;
using EmployeeManagement.Domain.Interfaces;
using EmployeeManagement.Application.Services;
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

        // AutoMapper
        services.AddAutoMapper(config =>
        {
            config.AddMaps(typeof(CreateUsersUseCase).Assembly);
        });

        // Helpers
        services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();

        // Register repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWorkInfoRepository, WorkInfoRepository>();
        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();

        // Register services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IAnnouncementService, AnnouncementService>();

        // UsersWithEmployee Use cases
        services.AddScoped<CreateUsersUseCase>();
        services.AddScoped<UpdateUserUseCase>();
        services.AddScoped<DeleteUsersUseCase>();
        services.AddScoped<GetUserUseCase>();
        services.AddScoped<GetAllUsersUseCase>();
        services.AddScoped<GetUsersByDepartmentUseCase>();

        // Tasks
        services.AddScoped<CreateTaskUseCase>();
        services.AddScoped<DeleteTaskUseCase>();
        services.AddScoped<GetAllTaskByUserUseCase>();
        services.AddScoped<GetTaskUseCase>();
        services.AddScoped<UpdateTaskUseCase>();

        // Departments
        services.AddScoped<CreateDepartmentUseCase>();
        services.AddScoped<DeleteDepartmentUseCase>();
        services.AddScoped<GetDepartmentUseCase>();
        services.AddScoped<GetAllDepartmentsUseCase>();
        services.AddScoped<UpdateDepartmentUseCase>();

        // Announcements
        services.AddScoped<CreateAnnouncementUseCase>();
        services.AddScoped<DeleteAnnouncementUseCase>();
        services.AddScoped<GetAllAnnouncementsUseCase>();
        services.AddScoped<GetAnnouncementUseCase>();
        services.AddScoped<UpdateAnnouncementUseCase>();


        return services;
    }
}
