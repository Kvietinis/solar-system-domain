using ThreatAssessment.Application.Interfaces;
using ThreatAssessment.Domain;
using ThreatAssessment.Domain.DomainEvents;

namespace ThreatAssessment.Infrastructure
{
    public class DomainEventDispatcher(IDomainEventHandler<SeverityChanged> eventHandler) : IDomainEventDispatcher
    {
        private readonly IDomainEventHandler<SeverityChanged> _eventHandler = eventHandler;

        public async Task Dispatch<T>(T domainEvent) where T : IIsDomainEvent
        {
            await NonsensicalInternalDispatch(domainEvent).ConfigureAwait(false);
        }

        private async Task NonsensicalInternalDispatch<T>(T domainEvent) where T : IIsDomainEvent
        {
            var SeverityChanged = domainEvent as SeverityChanged;

            if (SeverityChanged != null)
            {
                await _eventHandler.Handle(SeverityChanged).ConfigureAwait(false);
            }

            throw new NotImplementedException();
        }
    }
}
