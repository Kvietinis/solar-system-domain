namespace Catalog.Domain.DomainEvents
{
    public interface IIsDomainEvent
    {
        Guid Id { get; }

        string EventName { get; }
    }
}
