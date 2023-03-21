using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Prueba.Adapters.DataAccess;
using Prueba.Adapters.EntityFramework;
using Prueba.Domain.others;
using Prueba.Domain.Ports.DataAccess;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("Defaultconnection");
builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer(connectionString));
builder.Services.AddMediatR(typeof (Prueba.Application.UseCases.CreateUser));
builder.Services.AddMediatR(typeof(Prueba.Application.UseCases.ListUser));
builder.Services.AddMediatR(typeof(Prueba.Application.UseCases.GetUser));
builder.Services.AddMediatR(typeof(Prueba.Application.UseCases.UpdateUser));
builder.Services.AddMediatR(typeof(Prueba.Application.UseCases.DeleteUser));
builder.Services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddValidatorsFromAssembly( typeof(Prueba.Application.UseCases.CreateUser).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(Prueba.Application.UseCases.ListUser).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(Prueba.Application.UseCases.UpdateUser).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        var exceptionHandlerPathFeature =
           context.Features.Get<IExceptionHandlerPathFeature>();
        if (exceptionHandlerPathFeature?.Error is ValidationException validationException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            var errors = validationException.Errors;
            await context.Response.WriteAsJsonAsync(errors);
            return;
        }
        if (exceptionHandlerPathFeature?.Error is BusinessException validationException2)
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            var errors = validationException2.Message;
            await context.Response.WriteAsJsonAsync(errors);
            return;
        }

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
    });
});
app.MapControllers();

app.Run();
