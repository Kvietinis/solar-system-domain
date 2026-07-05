using Orbit.Domain;
using Orbit.Domain.Repositories;
using OrbitAggregate = Orbit.Domain.Aggregates.Orbit;

namespace Orbit.Infrastructure
{
    public class SqlOrbitRepository(IDomainEventDispatcher dispatcher) : IOrbitRepository
    {
        private readonly IDomainEventDispatcher _dispatcher = dispatcher;

        public Task<OrbitAggregate> Load(Guid? id)
        {
            if (!id.HasValue)
            {
                return Task.FromResult(new OrbitAggregate());
            }

            // gets DB entity or entities from DBContext and creates Aggregate
            throw new NotImplementedException();
        }

        public async Task Store(OrbitAggregate aggregate)
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
