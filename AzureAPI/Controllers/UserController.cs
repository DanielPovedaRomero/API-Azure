using AzureAPI.BL;
using AzureAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AzureAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserBL _usuarioBL;

        public UserController(IConfiguration config)
        {
            _usuarioBL = new UserBL(config.GetConnectionString("DefaultConnection"));
        }

        [HttpGet]
        public IActionResult Get()
        {
            var resultado = _usuarioBL.ObtenerUsuarios();
            if (resultado.Exito)
            {
                return Ok(resultado);
            }
            return NotFound(resultado);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var resultado = _usuarioBL.ObtenerUsuarioPorId(id);
            if (resultado.Exito)
            {
                return Ok(resultado);
            }
            return NotFound(resultado);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User usuario)
        {
            var resultado = _usuarioBL.InsertarUsuario(usuario);
            if (resultado.Exito)
            {
                return CreatedAtAction(nameof(Get), new { id = resultado.Datos.IdUsuario }, resultado);
            }
            return BadRequest(resultado);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User usuario)
        {
            usuario.IdUsuario = id;
            var resultado = _usuarioBL.ActualizarUsuario(usuario);
            if (resultado.Exito)
            {
                return Ok(resultado);
            }
            return NotFound(resultado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var resultado = _usuarioBL.EliminarUsuario(id);
            if (resultado.Exito)
            {
                return Ok(resultado);
            }
            return NotFound(resultado);
        }
    }
}