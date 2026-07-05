namespace Orbit.Application.Commands
{
    public record OrbitUpsertCommand
    {
        public required Guid SolarSystemObjectId { get; init; }

        public required double Trajectory { get; init; }

        public required double Velocity { get; init; }
    }
}
