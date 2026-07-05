namespace ThreatAssessment.Application.Dtos
{
    public class OrbitChangedDto
    {
        public required Guid Id { get; init; }

        public required double Trajectory { get; init; }

        public required double Velocity { get; init; }
    }
}
