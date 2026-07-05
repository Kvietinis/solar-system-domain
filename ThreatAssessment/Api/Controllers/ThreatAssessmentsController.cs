using Microsoft.AspNetCore.Mvc;
using ThreatAssessment.Application.Commands;
using ThreatAssessment.Application.UseCases;

namespace ThreatAssessment.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ThreatAssessmentsController(UpdateThreatAssessment updateThreatAssessmentUseCase) : ControllerBase
    {
        private readonly UpdateThreatAssessment _updateThreatAssessmentUseCase = updateThreatAssessmentUseCase;

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(ThreatAssessmentUpsertCommand command)
        {
            var result = await _updateThreatAssessmentUseCase.Execute(command).ConfigureAwait(false);
            var uri = $"api/v1/threatassessments/{result}";

            return Created(uri, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(ThreatAssessmentUpsertCommand command, Guid id)
        {
            await _updateThreatAssessmentUseCase.Execute(command, id).ConfigureAwait(false);

            return NoContent();
        }
    }
}
