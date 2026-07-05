namespace ThreatAssessment.Domain.DomainEvents
{
    public interface IIsDomainEvent
    {
        Guid Id { get; }

        string EventName { get; }
    }
}
