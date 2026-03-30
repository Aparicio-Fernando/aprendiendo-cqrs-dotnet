using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Commands.Productos;
using TiendaAPI.Handlers.Commands;
using TiendaAPI.Handlers.Queries;
using TiendaAPI.Interfaces;
using TiendaAPI.Queries.Productos;
using TiendaAPI.Servicios;

namespace TiendaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ICommandHandler<CrearProductoCommand> _crearHandler;
        private readonly IQueryHandler<ObtenerProductosQuery, List<string>> _obtenerHandler;

        public ProductosController(
            ICommandHandler<CrearProductoCommand> crearHandler,
            IQueryHandler<ObtenerProductosQuery, List<string>> obtenerHandler)
        {
            _crearHandler = crearHandler;
            _obtenerHandler = obtenerHandler;
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var query = new ObtenerProductosQuery();
            var resultado = await  _obtenerHandler.Handle(query);
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
