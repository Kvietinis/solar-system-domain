using Libs;
using Orbit.Application.Commands;
using Orbit.Application.Dtos;
using Orbit.Application.Interfaces;
using Orbit.Application.UseCases;

namespace Orbit.Application.IntegrationEventHandlers
{
    public class SolarSystemObjectCangedEventHandler(
        ISomeMagicalTrajectoryCalculator trajectoryCalculator,
        ISomeMagicalVelocityCalculator velocityCalculator,
        UpdateOrbit updateOrbit) : IIntegrationEventHandler<SolarSystemObjectChangedDto>
    {
        private readonly ISomeMagicalTrajectoryCalculator _trajectoryCalculator = trajectoryCalculator;
        private readonly ISomeMagicalVelocityCalculator _velocityCalculator = velocityCalculator;
        private readonly UpdateOrbit _updateOrbitUseCase = updateOrbit;

        public async Task Handle(SolarSystemObjectChangedDto message)
        {
            var command = await ToCommand(message);

            await _updateOrbitUseCase.Execute(command).ConfigureAwait(false);
        }

        private async Task<OrbitUpsertCommand> ToCommand(SolarSystemObjectChangedDto dto)
        {
            var trajectory = await _trajectoryCalculator.ByMass(dto.Mass).ConfigureAwait(false);
            var velocity = await _velocityCalculator.ByMass(dto.Mass).ConfigureAwait(false);

            var result = new OrbitUpsertCommand
            {
                SolarSystemObjectId = dto.Id,
                Trajectory = trajectory,
                Velocity = velocity
            };

            return result;
        }
    }
}
