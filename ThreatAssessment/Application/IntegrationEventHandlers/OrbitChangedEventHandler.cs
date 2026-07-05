using ThreatAssessment.Application.Commands;
using ThreatAssessment.Application.Dtos;
using ThreatAssessment.Application.Interfaces;
using ThreatAssessment.Application.UseCases;

namespace ThreatAssessment.Application.IntegrationEventHandlers
{
    public class OrbitChangedEventHandler(UpdateThreatAssessment updateThreatAssessment) : IIntegrationEventHandler<OrbitChangedDto>
    {
        private readonly UpdateThreatAssessment _updateThreatAssessmentUseCase = updateThreatAssessment;

        public async Task Handle(OrbitChangedDto message)
        {
            var command = ToCommand(message);

            await _updateThreatAssessmentUseCase.Execute(command, message.Id).ConfigureAwait(false);
        }

        private static ThreatAssessmentUpsertCommand ToCommand(OrbitChangedDto dto)
        {
            var result = new ThreatAssessmentUpsertCommand
            {
                OrbitId = dto.Id,
                Trajectory = dto.Trajectory,
                Velocity = dto.Velocity
            };

            return result;
        }
    }
}
