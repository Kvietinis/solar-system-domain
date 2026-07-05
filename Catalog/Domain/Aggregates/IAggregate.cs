using Catalog.Domain.DomainEvents;

namespace Catalog.Domain.Aggregates
{
    public interface IAggregate
    {
        IIsDomainEvent[] GetEvents();
    }
}
