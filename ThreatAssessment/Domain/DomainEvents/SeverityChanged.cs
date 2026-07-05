using ThreatAssessment.Domain.ValueObjects;

namespace ThreatAssessment.Domain.DomainEvents
{
    public record SeverityChanged : IIsDomainEvent
    {
        public Guid Id { get; init; }

        public Severity Severity { get; init; }

        public string EventName => nameof(SeverityChanged);
    }
}
