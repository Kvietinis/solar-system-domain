using ThreatAssessment.Application.IntegrationEvents;
using ThreatAssessment.Application.Interfaces;
using ThreatAssessment.Domain.DomainEvents;

namespace ThreatAssessment.Application.DomainEventHandlers
{
    public class SeverityChangedEventHandler(IPublisher publisher) : IDomainEventHandler<SeverityChanged>
    {
        private readonly IPublisher _publisher = publisher;

        public async Task Handle(SeverityChanged domainEvent)
        {
            var integrationEvent = ToIntegrationEvent(domainEvent);

            await _publisher.Publish(integrationEvent).ConfigureAwait(false);
        }

        private static ThreatCalculated ToIntegrationEvent(SeverityChanged domainEvent)
        {
            var result = new ThreatCalculated
            {
                Id = domainEvent.Id,
                Threat = (int)domainEvent.Severity
            };

            return result;
        }
    }
}
