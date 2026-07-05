using Catalog.Domain;
using Catalog.Domain.Aggregates;
using Catalog.Domain.Repositories;

namespace Catalog.Infrastructure
{
    public class SqlSolarSystemObjectRepository(IDomainEventDispatcher dispatcher) : ISolarSystemObjectRepository
    {
        private readonly IDomainEventDispatcher _dispatcher = dispatcher;

        public Task<SolarSystemObject> Load(Guid? id)
        {
            if (!id.HasValue)
            {
                return Task.FromResult(new SolarSystemObject());
            }

            // gets DB entity or entities from DBContext and creates Aggregate
            throw new NotImplementedException();
        }

        public async Task Store(SolarSystemObject aggregate)
        {
            try
            {
                // map aggregate to DB entity or entities and commit the transaction

                foreach (var domainEvent in aggregate.GetEvents())
                {
                    await _dispatcher.Dispatch(domainEvent).ConfigureAwait(false);
                }
            }
            catch
            {
                // mostly to handle unsuccessfull DB commit
                throw new NotImplementedException();
            }
        }
    }
}
