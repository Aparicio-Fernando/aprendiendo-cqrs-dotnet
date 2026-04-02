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
        private readonly ICommandHandler<CrearProductoCommand> _crearHandler;
        private readonly IQueryHandler<ObtenerProductosQuery, List<ProductoDto>> _obtenerHandler;
        private readonly IQueryHandler<ObtenerProductoPorIdQuery, ProductoDto?> _obtenerPorIdHandler;

        public ProductosController(
            ICommandHandler<CrearProductoCommand> crearHandler,
            IQueryHandler<ObtenerProductosQuery, List<ProductoDto>> obtenerHandler,
            IQueryHandler<ObtenerProductoPorIdQuery, ProductoDto?> obtenerPorIdHandler)

        {
            _crearHandler = crearHandler;
            _obtenerHandler = obtenerHandler;
            _obtenerPorIdHandler = obtenerPorIdHandler;
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var query = new ObtenerProductosQuery();
            var resultado = await _obtenerHandler.Handle(query);
            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var query = new ObtenerProductoPorIdQuery(id);
            var resultado = await _obtenerPorIdHandler.Handle(query);

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
            var resultado = await _crearHandler.Handle(command);
            return Ok(resultado);
        }


    }
}
