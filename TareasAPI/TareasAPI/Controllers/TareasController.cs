using MediatR;
using Microsoft.AspNetCore.Mvc;
using TareasAPI.Command.Tareas;
using TareasAPI.Queries.Tareas;

namespace TareasAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private readonly IMediator _mediador;

        public TareasController(IMediator mediador)
        {
            _mediador = mediador;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTareas()
        {
            var query = new ObtenerTareasQuery();
            var resultado = await _mediador.Send(query);
            return Ok(resultado);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerTareaPorId(int id)
        {
            var query = new ObtenerTareaPorIdQuery(id);
            var resultado = await _mediador.Send(query);

            if (resultado is null)
                return NotFound($"Tarea con Id {id} no encontrada");

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> CrearTarea([FromBody] CrearTareaCommand command)
        {
            var resultado = await _mediador.Send(command);
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> CompletarTarea(int id)
        {
            var resultado = await _mediador.Send(new CompletarTareaCommand(id));
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarTarea(int id)
        {
            var resultado = await _mediador.Send(new EliminarTareaCommand(id));
            return Ok(resultado);
        }
    }
}
