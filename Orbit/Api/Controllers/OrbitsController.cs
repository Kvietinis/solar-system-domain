using Microsoft.AspNetCore.Mvc;
using Orbit.Application.Commands;
using Orbit.Application.UseCases;

namespace Orbit.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrbitsController(UpdateOrbit updateOrbitUseCase) : ControllerBase
    {
        private readonly UpdateOrbit _updateOrbitUseCase = updateOrbitUseCase;

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(OrbitUpsertCommand createCommand)
        {
            var result = await _updateOrbitUseCase.Execute(createCommand).ConfigureAwait(false);
            var uri = $"api/v1/solarsystemobjects/{result}";

            return Created(uri, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Post(OrbitUpsertCommand createCommand, Guid id)
        {
            await _updateOrbitUseCase.Execute(createCommand, id).ConfigureAwait(false);

            return NoContent();
        }
    }
}
