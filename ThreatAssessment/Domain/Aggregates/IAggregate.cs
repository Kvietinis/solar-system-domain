using ThreatAssessment.Domain.DomainEvents;

namespace ThreatAssessment.Domain.Aggregates
{
    public interface IAggregate
    {
        IIsDomainEvent[] GetEvents();
    }
}
