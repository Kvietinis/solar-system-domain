using Catalog.Domain.DomainEvents;

namespace Catalog.Application.Interfaces
{
    public interface IDomainEventHandler<T> where T : IIsDomainEvent
    {
        Task Handle(T domainEvent);
    }
}
