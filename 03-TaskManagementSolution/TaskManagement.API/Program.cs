using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TaskManagement.Application.Common.Decorators;
using TaskManagement.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register MediatR (correct way)
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
);

// Register Repository
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();

builder.Services.AddTransient(typeof(IRequestHandler<,>), typeof(LoggingDecorator<,>));

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
