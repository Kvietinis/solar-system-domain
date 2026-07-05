using Catalog.Domain.DomainEvents;

namespace Catalog.Domain
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch<T>(T domainEvent) where T : IIsDomainEvent;
    }
}
