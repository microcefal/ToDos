using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TaskManagerClean.Application.Services;
using TaskManagerClean.Application.UseCases.Handllers;
using TaskManagerClean.Domain.Data;
using TaskManagerClean.Infrastructure.Data;
using TaskManagerClean.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("https://localhost:7197") 
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<ITaskRepository, TaskRepository>(); 

builder.Services.AddScoped<TaskService>(); 


builder.Services.AddScoped<UpdateTaskHandler>();
builder.Services.AddScoped<UpdateDetalisTaskHandler>();
builder.Services.AddScoped<CreateTaskHandler>();
builder.Services.AddScoped<DeleteTaskHandler>();
builder.Services.AddScoped<GetTaskByIdHandler>();
builder.Services.AddScoped<GetTaskByStatusHandler>();
builder.Services.AddScoped<GetAllTaskHandler>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NoteManager API", Version = "v1" });
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "NoteManager API v1");
    });
}
app.UseStaticFiles();
app.UseCors("AllowFrontend"); 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
