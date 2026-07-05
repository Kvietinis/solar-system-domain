namespace Catalog.Application.IntegrationEvents
{
    public record SolarSystemObjectChanged
    {
        public Guid Id { get; init; }

        public double Mass { get; init; }
    }
}
