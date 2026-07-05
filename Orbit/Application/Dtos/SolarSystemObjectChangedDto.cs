namespace Orbit.Application.Dtos
{
    public record SolarSystemObjectChangedDto
    {
        public Guid Id { get; init; }

        public double Mass { get; init; }
    }
}
