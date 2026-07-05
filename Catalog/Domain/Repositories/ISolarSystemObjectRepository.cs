using Catalog.Domain.Aggregates;

namespace Catalog.Domain.Repositories
{
    public interface ISolarSystemObjectRepository
    {
        Task<SolarSystemObject> Load(Guid? id);

        Task Store(SolarSystemObject aggregate);
    }
}
