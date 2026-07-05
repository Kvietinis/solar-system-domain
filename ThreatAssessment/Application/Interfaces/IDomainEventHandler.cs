using ThreatAssessment.Domain.DomainEvents;

namespace ThreatAssessment.Application.Interfaces
{
    public interface IDomainEventHandler<T> where T : IIsDomainEvent
    {
        Task Handle(T domainEvent);
    }
}
