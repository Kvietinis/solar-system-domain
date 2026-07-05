using Orbit.Domain.DomainEvents;

namespace Orbit.Domain
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch<T>(T domainEvent) where T : IIsDomainEvent;
    }
}
