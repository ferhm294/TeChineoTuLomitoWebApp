using Microsoft.AspNetCore.Mvc;
using API_TeChineoTuLomito.Data;
using API_TeChineoTuLomito.Models;

namespace API_TeChineoTuLomito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedimientoController : ControllerBase
    {
        private readonly MemoriaProcedimiento _memoria;

        public ProcedimientoController(DBContexto contexto)
        {
            _memoria = new MemoriaProcedimiento(contexto);
        }

        // GET: api/Procedimiento
        [HttpGet]
        public ActionResult<List<Procedimiento>> Get()
        {
            return _memoria.ObtenerLista();
        }

        // GET: api/Procedimiento/{id}
        [HttpGet("{id}")]
        public ActionResult<Procedimiento> Get(int id)
        {
            var procedimiento = _memoria.ObtenerPorId(id);
            if (procedimiento == null)
                return NotFound();
            return procedimiento;
        }

        // POST: api/Procedimiento
        [HttpPost]
        public ActionResult<Procedimiento> Post([FromBody] Procedimiento nuevoProcedimiento)
        {
            if (nuevoProcedimiento == null)
                return BadRequest("Procedimiento inválido.");

            var existente = _memoria.ObtenerPorId(nuevoProcedimiento.id);
            if (existente != null)
                return Conflict("Ya existe un procedimiento con ese ID.");

            _memoria.Agregar(nuevoProcedimiento);
            return CreatedAtAction(nameof(Get), new { id = nuevoProcedimiento.id }, nuevoProcedimiento);
        }

        // PUT: api/Procedimiento/{id}
        [HttpPut("{id}")]
        public ActionResult<Procedimiento> Put(int id, [FromBody] Procedimiento procedimientoActualizado)
        {
            if (procedimientoActualizado == null || id != procedimientoActualizado.id)
                return BadRequest("ID no coincide.");

            var actualizado = _memoria.Editar(procedimientoActualizado);
            if (actualizado == null)
                return NotFound();

            return Ok(actualizado);
        }

        // DELETE: api/Procedimiento/{id}
        [HttpDelete("{id}")]
        public ActionResult<Procedimiento> Delete(int id)
        {
            var eliminado = _memoria.Eliminar(id);
            if (eliminado == null)
                return NotFound();

            return Ok(eliminado);
        }
    }
}
