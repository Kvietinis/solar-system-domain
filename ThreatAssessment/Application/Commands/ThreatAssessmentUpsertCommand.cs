namespace ThreatAssessment.Application.Commands
{
    public class ThreatAssessmentUpsertCommand
    {
        public required Guid OrbitId { get; init; }

        public required double Trajectory { get; init; }

        public required double Velocity { get; init; }
    }
}
