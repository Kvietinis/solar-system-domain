using ThreatAssessment.Domain;
using ThreatAssessment.Domain.Repositories;
using ThreatAssessmentAggregate = ThreatAssessment.Domain.Aggregates.ThreatAssessment;

namespace ThreatAssessment.Infrastructure
{
    public class SqlThreatAssessmentRepository(IDomainEventDispatcher dispatcher) : IThreatAssessmentRepository
    {
        private readonly IDomainEventDispatcher _dispatcher = dispatcher;

        public Task<ThreatAssessmentAggregate> Load(Guid? id)
        {
            if (!id.HasValue)
            {
                return Task.FromResult(new ThreatAssessmentAggregate());
            }

            // gets DB entity or entities from DBContext and creates Aggregate
            throw new NotImplementedException();
        }

        public Task<ThreatAssessmentAggregate> LoadByOrbitId(Guid orbitId)
        {
            // try get by orbitId if not return default

            throw new NotImplementedException();
        }

        public async Task Store(ThreatAssessmentAggregate aggregate)
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
