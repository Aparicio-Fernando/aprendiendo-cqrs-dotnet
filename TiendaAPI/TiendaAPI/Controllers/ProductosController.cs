using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Commands.Productos;
using TiendaAPI.Handlers.Commands;
using TiendaAPI.Handlers.Queries;
using TiendaAPI.Queries.Productos;
using TiendaAPI.Servicios;

namespace TiendaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly CrearProductoHandler _crearHandler;
        private readonly ObtenerProductosHandler _obtenerHandler;

        public ProductosController(
            CrearProductoHandler crearHandler,
            ObtenerProductosHandler obtenerHandler)
        {
            _crearHandler = crearHandler;
            _obtenerHandler = obtenerHandler;
        }

        //GET api/productos
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var query = new ObtenerProductosQuery();
            var resultado = _obtenerHandler.Handle(query);
            return Ok(resultado);
        }

        //GET api/productos/5
        //[HttpGet("{id}")]
        //public IActionResult ObtenerPorId(int id)
        //{
        //    return Ok(_servicio.ObtenerPorId(id));
        //}

        //POST api/productos
        [HttpPost]
        public IActionResult Crear([FromBody] CrearProductoCommand command)
        {
            var resultado = _crearHandler.Handle(command);
            return Ok(resultado);
        }

        //DELETE api/productos/5
        //[HttpDelete("{id}")]
        //public IActionResult Eliminar(int id)
        //{
        //    return Ok(_servicio.Eliminar(id));
        //}
    }
}
