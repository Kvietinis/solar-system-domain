using ThreatAssessmentAggregate = ThreatAssessment.Domain.Aggregates.ThreatAssessment;

namespace ThreatAssessment.Domain.Repositories
{
    public interface IThreatAssessmentRepository
    {
        Task<ThreatAssessmentAggregate> Load(Guid? id);

        Task<ThreatAssessmentAggregate> LoadByOrbitId(Guid id);

        Task Store(ThreatAssessmentAggregate aggregate);
    }
}
