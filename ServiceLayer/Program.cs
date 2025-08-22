using BusinessLayer.CQRS.Commands.Venta;
using DataLayer;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.CQRS.Queries.Producto;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Obtener connection string 
var connectionString =
    builder.Configuration.GetConnectionString("AbarrotesBD")
        ?? throw new InvalidOperationException("Connection string"
        + "'AbarrotesBD' not found.");

//Hacer inyeccion de dependencia(connection string)
builder.Services.AddDbContext<AbarrotesBdContext>(options =>
    options.UseSqlServer(connectionString));

//Mediator handler
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(ProductoQuery).Assembly));

// Registro de validadores automáticamente
builder.Services.AddValidatorsFromAssemblyContaining<RegistrarVentaCommandValidator>();

// Activa la validación automática
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
