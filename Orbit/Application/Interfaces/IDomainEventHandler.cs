using Orbit.Domain.DomainEvents;

namespace Orbit.Application.Interfaces
{
    public interface IDomainEventHandler<T> where T : IIsDomainEvent
    {
        Task Handle(T domainEvent);
    }
}
