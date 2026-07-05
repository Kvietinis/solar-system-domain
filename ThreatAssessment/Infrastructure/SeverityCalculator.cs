using ThreatAssessment.Domain;
using ThreatAssessment.Domain.ValueObjects;

namespace ThreatAssessment.Infrastructure
{
    public class SeverityCalculator : ISeverityCalculator
    {
        public Task<Severity> ByTrajectoryAndVelocity(double trajectory, double velocity)
        {
            // some calculation
            throw new NotImplementedException();
        }
    }
}
