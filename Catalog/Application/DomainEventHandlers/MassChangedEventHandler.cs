using Catalog.Application.IntegrationEvents;
using Catalog.Application.Interfaces;
using Catalog.Domain.DomainEvents;

namespace Catalog.Application.DomainEventHandlers
{
    public class MassChangedEventHandler(IPublisher publisher) : IDomainEventHandler<MassChanged>
    {
        private readonly IPublisher _publisher = publisher;

        public async Task Handle(MassChanged domainEvent)
        {
            var integrationEvent = ToIntegrationEvent(domainEvent);

            await _publisher.Publish(integrationEvent);
        }

        private static SolarSystemObjectChanged ToIntegrationEvent(MassChanged domainEvent)
        {
            var result = new SolarSystemObjectChanged
            {
                Id = domainEvent.Id,
                Mass = domainEvent.Mass.Value
            };

            return result;
        }
    }
}
