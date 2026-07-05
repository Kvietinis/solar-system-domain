using Orbit.Application.Interfaces;
using Orbit.Domain;
using Orbit.Domain.DomainEvents;

namespace Orbit.Infrastructure
{
    public class DomainEventDispatcher(IDomainEventHandler<TrajectoryOrVelocityChanged> eventHandler) : IDomainEventDispatcher
    {
        private readonly IDomainEventHandler<TrajectoryOrVelocityChanged> _eventHandler = eventHandler;

        public async Task Dispatch<T>(T domainEvent) where T : IIsDomainEvent
        {
            await NonsensicalInternalDispatch(domainEvent).ConfigureAwait(false);
        }

        private async Task NonsensicalInternalDispatch<T>(T domainEvent) where T : IIsDomainEvent
        {
            var trajectoryOrVelocityChanged = domainEvent as TrajectoryOrVelocityChanged;

            if (trajectoryOrVelocityChanged != null)
            {
                await _eventHandler.Handle(trajectoryOrVelocityChanged).ConfigureAwait(false);
            }

            throw new NotImplementedException();
        }
    }
}
