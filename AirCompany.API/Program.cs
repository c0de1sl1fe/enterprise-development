using System.Reflection;
using AirCompany.API;
using AirCompany.API.DTO;
using AirCompany.API.Services;
using AirCompany.Domain;
using AirCompany.Domain.Entities;
using AirCompany.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddScoped<IService<AircraftDto, AircraftFullDto>, AircraftService>();
builder.Services.AddScoped<IService<FlightDto, FlightFullDto>, FlightService>();
builder.Services.AddScoped<IService<PassengerDto, PassengerFullDto>, PassengerService>();
builder.Services.AddScoped<IService<RegisteredPassengerDto, RegisteredPassengerFullDto>, RegisteredPassengerService>();
builder.Services.AddScoped<IQueryService, QueryService>();

builder.Services.AddScoped<IRepository<Aircraft>, AircraftRepository>();
builder.Services.AddScoped<IRepository<Flight>, FlightRepository>();
builder.Services.AddScoped<IRepository<Passenger>, PassengerRepository>();
builder.Services.AddScoped<IRepository<RegisteredPassenger>, RegisteredPassengerRepository>();

builder.Services.AddDbContext<AirCompanyContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgre")));

builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();