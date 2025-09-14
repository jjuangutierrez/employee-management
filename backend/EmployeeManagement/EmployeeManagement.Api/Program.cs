using EmployeeManagement.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureService(builder.Configuration);

WebApplication app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
