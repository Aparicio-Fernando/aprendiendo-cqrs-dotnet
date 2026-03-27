using Microsoft.AspNetCore.Mvc;
using TiendaAPI.Servicios;

namespace TiendaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoServicio _servicio;

        public ProductosController(IProductoServicio servicio)
        {
            _servicio = servicio;
        }

        //GET api/productos
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
           return Ok(_servicio.ObtenerTodos());
        }

        //GET api/productos/5
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            return Ok(_servicio.ObtenerPorId(id));
        }

        //POST api/productos
        [HttpPost]
        public IActionResult Crear([FromBody] string nombre)
        {
            return Ok(_servicio.Crear(nombre));
        }

        //DELETE api/productos/5
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            return Ok(_servicio.Eliminar(id));
        }
    }
}
