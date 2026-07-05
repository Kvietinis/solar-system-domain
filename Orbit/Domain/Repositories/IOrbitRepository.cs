using OrbitAggregate = Orbit.Domain.Aggregates.Orbit;

namespace Orbit.Domain.Repositories
{
    public interface IOrbitRepository
    {
        Task<OrbitAggregate> Load(Guid? id);

        Task Store(OrbitAggregate aggregate);
    }
}
