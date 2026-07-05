using Orbit.Application.IntegrationEvents;
using Orbit.Application.Interfaces;
using Orbit.Domain.DomainEvents;

namespace Orbit.Application.DomainEventHandlers
{
    public class TrajectoryOrVelocityChangedEventHandler(IPublisher publisher) : IDomainEventHandler<TrajectoryOrVelocityChanged>
    {
        private readonly IPublisher _publisher = publisher;

        public async Task Handle(TrajectoryOrVelocityChanged domainEvent)
        {
            var integrationEvent = ToIntegrationEvent(domainEvent);

            await _publisher.Publish(integrationEvent).ConfigureAwait(false);
        }

        private static OrbitChanged ToIntegrationEvent(TrajectoryOrVelocityChanged domainEvent)
        {
            var result = new OrbitChanged
            {
                Id = domainEvent.Id,
                Trajectory = domainEvent.Trajectory?.Value,
                Velocity = domainEvent.Velocity?.Value,
            };

            return result;
        }
    }
}
