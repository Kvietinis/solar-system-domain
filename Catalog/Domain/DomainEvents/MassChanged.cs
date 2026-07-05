using Catalog.Domain.ValueObjects;

namespace Catalog.Domain.DomainEvents
{
    public record MassChanged : IIsDomainEvent
    {
        public Guid Id { get; init; }

        public Mass Mass { get; init; } = Mass.FromDouble(0);

        public string EventName => nameof(MassChanged);
    }
}
