using ThreatAssessment.Domain.DomainEvents;

namespace ThreatAssessment.Domain
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch<T>(T domainEvent) where T : IIsDomainEvent;
    }
}
