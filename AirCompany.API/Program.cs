using System.Reflection;
using AirCompany.API;
using AirCompany.API.DTO;
using AirCompany.API.Services;
using AirCompany.Domain.Entities;
using AirCompany.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddSingleton<IService<AircraftDto, AircraftFullDto>, AircraftService>();
builder.Services.AddSingleton<IService<FlightDto, FlightFullDto>, FlightService>();
builder.Services.AddSingleton<IService<PassengerDto, PassengerFullDto>, PassengerService>();
builder.Services.AddSingleton<IService<RegisteredPassengerDto, RegisteredPassengerFullDto>, RegisteredPassengerService>();
builder.Services.AddSingleton<IQueryService, QueryService>();
builder.Services.AddSingleton<IRepository<Aircraft>, AircraftRepository>();
builder.Services.AddSingleton<IRepository<Flight>, FlightRepository>();
builder.Services.AddSingleton<IRepository<Passenger>, PassengerRepository>();
builder.Services.AddSingleton<IRepository<RegisteredPassenger>, RegisteredPassengerRepository>();

builder.Services.AddControllers();

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