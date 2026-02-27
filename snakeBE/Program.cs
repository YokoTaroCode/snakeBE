using SharpGrip.FluentValidation.AutoValidation.Mvc​.Extensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using A_snakeBE.Middlewares;
using SnakeBE.Infrastructure.db;
using SnakeBE.Application;
using SnakeBE.Application.services;
using SnakeBE.Infrastructure.Repository.Interfaces;
using SnakeBE.Infrastructure.Repository;
using B_Infrastructure.Interfaces;

/*
 * requisiti individuati: 
 * - Il gioco DEVE essere legato ad un determinato utente 
 * - Un utente PUO avere più giochi associati
 * - Il gioco DEVE avere un punteggio, un tempo e una data di creazione
 * - Il DEVE ESSERE registrato SOLO se l'utente è registrato 
 * - Il gioco DEVE ESSERE eliminato SOLO se esiste nel contesto
 * - L'utente DEVE ESSERE eliminato SOLO se esiste nel contesto 
 * - Il gioco DEVE ESSERE eliminato se l'utente associato viene eliminato (cascade delete)
 * - l'utente NON DEVE ESSERE eliminato se vengono eliminati giochi associati (restrizione)
 * 
 * 
 * funzionalità da aggiungere: 
 * - Registrazione di un nuovo utente
 * - Registrazione di un nuovo gioco associato ad un utente già registrato
 * - 
 */
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

