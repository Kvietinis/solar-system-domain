using Orbit.Domain.DomainEvents;

namespace Orbit.Domain.Aggregates
{
    public interface IAggregate
    {
        IIsDomainEvent[] GetEvents();
    }
}
