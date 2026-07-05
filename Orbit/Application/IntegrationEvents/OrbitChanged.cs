namespace Orbit.Application.IntegrationEvents
{
    public record OrbitChanged
    {
        public Guid Id { get; init; }

        public double? Trajectory { get; init; }

        public double? Velocity { get; init; }
    }
}
