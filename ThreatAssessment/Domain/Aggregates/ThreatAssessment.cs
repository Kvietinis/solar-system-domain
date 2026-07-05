using ThreatAssessment.Domain.DomainEvents;
using ThreatAssessment.Domain.ValueObjects;

namespace ThreatAssessment.Domain.Aggregates
{
    public class ThreatAssessment : IAggregate
    {
        private readonly List<IIsDomainEvent> _events = [];

        public Guid Id { get; private set; } = Guid.NewGuid();

        public Guid OrbitId { get; private set; } = Guid.NewGuid();

        public Severity Severity { get; private set; } = Severity.Unknown;

        public void ChangeOrbitId(Guid orbitId)
        {
            OrbitId = orbitId;
        }

        public void ChangeSeverity(Severity severity)
        {
            Severity = severity;
            _events.Add(new SeverityChanged { Id = Id, Severity = Severity });
        }

        public IIsDomainEvent[] GetEvents()
        {
            return [.. _events];
        }
    }
}
