using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Register MediatR (correct way)
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
);

// Register Repository
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
