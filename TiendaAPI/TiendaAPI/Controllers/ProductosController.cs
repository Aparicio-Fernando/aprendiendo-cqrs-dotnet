using Microsoft.AspNetCore.Mvc;

namespace TiendaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        //GET api/productos
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var productos = new List<string>
            {
                "Laptop", "Mouse", "Teclado"
            };

            return Ok(productos);
        }

        //GET api/productos/5
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            return Ok($"Producto número {id}");
        }

        //POST api/productos
        [HttpPost]
        public IActionResult Crear([FromBody] string nombre)
        {
            return Ok($"Producto '{nombre}' creado correctamente");
        }

        //DELETE api/productos/5
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            return Ok($"Producto número {id} eliminado");
        }
    }
}
