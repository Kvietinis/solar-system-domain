using Catalog.Application.Interfaces;
using Catalog.Domain;
using Catalog.Domain.DomainEvents;

namespace Catalog.Infrastructure
{
    public class DomainEventDispatcher(IDomainEventHandler<MassChanged> massChangedEventHandler) : IDomainEventDispatcher
    {
        private readonly IDomainEventHandler<MassChanged> _massChangedEventHandler = massChangedEventHandler;

        public async Task Dispatch<T>(T domainEvent) where T : IIsDomainEvent
        {
            await NonsensicalInternalDispatch(domainEvent).ConfigureAwait(false);
        }

        private async Task NonsensicalInternalDispatch<T>(T domainEvent) where T : IIsDomainEvent
        {
            var massChanged = domainEvent as MassChanged;

            if (massChanged != null)
            {
                await _massChangedEventHandler.Handle(massChanged).ConfigureAwait(false);
            }

            throw new NotImplementedException();
        }
    }
}
