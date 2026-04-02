using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Commands.Productos;
using TiendaAPI.DTOs;
using TiendaAPI.Interfaces;
using TiendaAPI.Queries.Productos;

namespace TiendaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IMediator _mediator;

        // Un solo IMediator reemplaza todos los Handlers del constructor
        public ProductosController(IMediator mediator)

        {
            _mediator = mediator;
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var query = new ObtenerProductosQuery();
            var resultado = await _mediator.Send(query);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var query = new ObtenerProductoPorIdQuery(id);
            var resultado = await _mediator.Send(query);

            if (resultado is null)
                return NotFound($"Producto con Id {id} no encontrado");

            return Ok(resultado);
        }
        /// <summary>
        /// carga producto
        /// </summary>    
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearProductoCommand command)
        {
            var resultado = await _mediator.Send(command);
            return Ok(resultado);
        }


    }
}
