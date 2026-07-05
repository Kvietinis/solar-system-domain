using OrbitAggregate = Orbit.Domain.Aggregates.Orbit;

namespace Orbit.Domain.Repositories
{
    public interface IOrbitRepository
    {
        Task<OrbitAggregate> Load(Guid? id);

        Task<OrbitAggregate> LoadByObjectId(Guid id);

        Task Store(OrbitAggregate aggregate);
    }
}
