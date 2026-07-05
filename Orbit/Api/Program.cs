using Libs;
using Orbit.Application.DomainEventHandlers;
using Orbit.Application.Interfaces;
using Orbit.Application.UseCases;
using Orbit.Domain;
using Orbit.Domain.DomainEvents;
using Orbit.Domain.Repositories;
using Orbit.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddTransient<ISomeMagicalVelocityCalculator, SomeMagicalVelocityCalculator>();
builder.Services.AddTransient<ISomeMagicalTrajectoryCalculator, SomeMagicalTrajectoryCalculator>();
builder.Services.AddTransient<UpdateOrbit>();
builder.Services.AddTransient<IPublisher, RabbitPublisher>();
builder.Services.AddScoped<IDomainEventHandler<TrajectoryOrVelocityChanged>, TrajectoryOrVelocityChangedEventHandler>();
builder.Services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
builder.Services.AddScoped<IOrbitRepository, SqlOrbitRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
