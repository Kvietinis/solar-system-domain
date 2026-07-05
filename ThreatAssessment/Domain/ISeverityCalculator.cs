using ThreatAssessment.Domain.ValueObjects;

namespace ThreatAssessment.Domain
{
    public interface ISeverityCalculator
    {
        Task<Severity> ByTrajectoryAndVelocity(double trajectory, double velocity);
    }
}
