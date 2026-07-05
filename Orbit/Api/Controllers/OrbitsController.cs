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
        public async Task<ActionResult<Guid>> Post(OrbitUpsertCommand command)
        {
            var result = await _updateOrbitUseCase.Execute(command).ConfigureAwait(false);
            var uri = $"api/v1/orbits/{result}";

            return Created(uri, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(OrbitUpsertCommand command, Guid id)
        {
            await _updateOrbitUseCase.Execute(command, id).ConfigureAwait(false);

            return NoContent();
        }
    }
}
