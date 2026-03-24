using Microsoft.AspNetCore.Mvc;
using API_TeChineoTuLomito.Data;
using API_TeChineoTuLomito.Models;

namespace API_TeChineoTuLomito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly MemoriaEmpleado _memoria;

        public EmpleadoController(DBContexto contexto)
        {
            _memoria = new MemoriaEmpleado(contexto);
        }

        // GET: api/Empleado
        [HttpGet]
        public ActionResult<List<Empleado>> Get()
        {
            return _memoria.ObtenerLista();
        }

        // GET: api/Empleado/{identificacion}
        [HttpGet("{identificacion}")]
        public ActionResult<Empleado> Get(string identificacion)
        {
            var empleado = _memoria.ObtenerPorIdentificacion(identificacion);
            if (empleado == null)
                return NotFound();
            return empleado;
        }

        // POST: api/Empleado
        [HttpPost]
        public ActionResult<Empleado> Post([FromBody] Empleado nuevoEmpleado)
        {
            if (nuevoEmpleado == null || string.IsNullOrEmpty(nuevoEmpleado.identificacion))
                return BadRequest("Empleado inválido o sin identificación.");

            var existente = _memoria.ObtenerPorIdentificacion(nuevoEmpleado.identificacion);
            if (existente != null)
                return Conflict("Ya existe un empleado con esa identificación.");

            _memoria.Agregar(nuevoEmpleado);
            return CreatedAtAction(nameof(Get), new { identificacion = nuevoEmpleado.identificacion }, nuevoEmpleado);
        }

        // PUT: api/Empleado/{identificacion}
        [HttpPut("{identificacion}")]
        public ActionResult<Empleado> Put(string identificacion, [FromBody] Empleado empleadoActualizado)
        {
            if (empleadoActualizado == null || identificacion != empleadoActualizado.identificacion)
                return BadRequest("Identificación no coincide.");

            var actualizado = _memoria.Editar(empleadoActualizado);
            if (actualizado == null)
                return NotFound();

            return Ok(actualizado);
        }

        // DELETE: api/Empleado/{identificacion}
        [HttpDelete("{identificacion}")]
        public ActionResult<Empleado> Delete(string identificacion)
        {
            var eliminado = _memoria.Eliminar(identificacion);
            if (eliminado == null)
                return NotFound();

            return Ok(eliminado);
        }
    }
}
