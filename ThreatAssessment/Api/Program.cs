using ThreatAssessment.Application.DomainEventHandlers;
using ThreatAssessment.Application.Interfaces;
using ThreatAssessment.Application.UseCases;
using ThreatAssessment.Domain;
using ThreatAssessment.Domain.DomainEvents;
using ThreatAssessment.Domain.Repositories;
using ThreatAssessment.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddTransient<UpdateThreatAssessment>();
builder.Services.AddTransient<IPublisher, RabbitPublisher>();
builder.Services.AddScoped<IDomainEventHandler<SeverityChanged>, SeverityChangedEventHandler>();
builder.Services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
builder.Services.AddScoped<IThreatAssessmentRepository, SqlThreatAssessmentRepository>();
builder.Services.AddTransient<ISeverityCalculator, SeverityCalculator>();

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
