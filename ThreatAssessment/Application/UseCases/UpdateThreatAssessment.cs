using ThreatAssessment.Application.Commands;
using ThreatAssessment.Domain;
using ThreatAssessment.Domain.Repositories;

namespace ThreatAssessment.Application.UseCases
{
    public class UpdateThreatAssessment(IThreatAssessmentRepository repository, ISeverityCalculator calculator)
    {
        private readonly IThreatAssessmentRepository _repository = repository;
        private readonly ISeverityCalculator _calculator = calculator;

        public async Task<Guid> Execute(ThreatAssessmentUpsertCommand command, Guid? id = null)
        {
            var aggregate = id.HasValue ?
                await _repository.Load(id).ConfigureAwait(false) :
                await _repository.LoadByOrbitId(command.OrbitId);

            var severity = await _calculator.ByTrajectoryAndVelocity(command.Trajectory, command.Velocity);

            aggregate.ChangeOrbitId(command.OrbitId);
            aggregate.ChangeSeverity(severity);

            await _repository.Store(aggregate).ConfigureAwait(false);

            return aggregate.Id;
        }
    }
}
