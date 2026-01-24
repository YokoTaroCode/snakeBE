using SharpGrip.FluentValidation.AutoValidation.Mvc​.Extensions;
using FluentValidation;
using B_Infrastructure.Interfaces;
using C_Application;
using B_Infrastructure.services;
using B_Infrastructure.repos;
using B_Infrastructure.db;
using Microsoft.EntityFrameworkCore;
using B_Infrastructure;
using A_snakeBE.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<ErrorHandlingMiddleware>();

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var conn = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<SnakeDbContext>(optBuilder => optBuilder.UseSqlServer(conn));

builder.Services.AddScoped<IGameRepo, GameRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

app.UseExceptionHandler( _ => { });
app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

