using Orbit.Application.Commands;
using Orbit.Domain.Repositories;
using Orbit.Domain.ValueObjects;

namespace Orbit.Application.UseCases
{
    public class UpdateOrbit(IOrbitRepository repository)
    {
        private readonly IOrbitRepository _repository = repository;

        public async Task<Guid> Execute(OrbitUpsertCommand command, Guid? id = null)
        {
            var aggregate = id.HasValue ?
                await _repository.Load(id).ConfigureAwait(false) :
                await _repository.LoadByObjectId(command.SolarSystemObjectId);

            aggregate.ChangeObjectId(command.SolarSystemObjectId);
            aggregate.ChangeTrajectoryOrVelocity(Trajectory.FromDouble(command.Trajectory), Velocity.FromDouble(command.Velocity));

            await _repository.Store(aggregate).ConfigureAwait(false);

            return aggregate.Id;
        }
    }
}
