using Catalog.Application.Commands;
using Catalog.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SolarSystemObjectsController(UpdateSolarSystemObject updateSolarSystemObjectUseCase) : ControllerBase
    {
        private readonly UpdateSolarSystemObject _updateSolarSystemObjectUseCase = updateSolarSystemObjectUseCase;

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(SolarSystemObjectUpsertCommand createCommand)
        {
            var result = await _updateSolarSystemObjectUseCase.Execute(createCommand).ConfigureAwait(false);
            var uri = $"api/v1/solarsystemobjects/{result}";

            return Created(uri, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, SolarSystemObjectUpsertCommand updateCommand)
        {
            await _updateSolarSystemObjectUseCase.Execute(updateCommand, id).ConfigureAwait(false);

            return NoContent();
        }
    }
}
