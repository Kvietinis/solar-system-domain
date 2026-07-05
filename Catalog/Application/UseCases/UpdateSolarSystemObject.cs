using Catalog.Application.Commands;
using Catalog.Domain.Repositories;
using Catalog.Domain.ValueObjects;

namespace Catalog.Application.UseCases
{
    public class UpdateSolarSystemObject(ISolarSystemObjectRepository repository)
    {
        private readonly ISolarSystemObjectRepository _repository = repository;

        public async Task<Guid> Execute(SolarSystemObjectUpsertCommand command, Guid? id = null)
        {
            var aggregate = await _repository.Load(id).ConfigureAwait(false);

            aggregate.AddName(command.Name);
            aggregate.ChangeMass(Mass.FromDouble(command.Mass));
            aggregate.ChangeClassification((Classification)command.Classification);

            await _repository.Store(aggregate).ConfigureAwait(false);

            return aggregate.Id;
        }
    }
}
