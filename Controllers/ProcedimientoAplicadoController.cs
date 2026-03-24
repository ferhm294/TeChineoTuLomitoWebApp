using Microsoft.AspNetCore.Mvc;
using API_TeChineoTuLomito.Data;
using API_TeChineoTuLomito.Models;

namespace API_TeChineoTuLomito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedimientoAplicadoController : ControllerBase
    {
        private readonly DBContexto _contexto;
        private readonly MemoriaProcedimientoAplicado _memoria;

        public ProcedimientoAplicadoController(DBContexto contexto)
        {
            _contexto = contexto;
            _memoria = new MemoriaProcedimientoAplicado(contexto);
        }

        // GET: api/ProcedimientoAplicado
        [HttpGet]
        public ActionResult<List<ProcedimientoAplicado>> Get()
        {
            return _memoria.ObtenerLista();
        }

        // GET: api/ProcedimientoAplicado/{id}
        [HttpGet("{id}")]
        public ActionResult<ProcedimientoAplicado> Get(int id)
        {
            var procedimiento = _memoria.ObtenerPorId(id);
            if (procedimiento == null)
                return NotFound($"No se encontró un procedimiento aplicado con id {id}.");
            return procedimiento;
        }

        // POST: api/ProcedimientoAplicado
        [HttpPost]
        public ActionResult<ProcedimientoAplicado> Post([FromBody] ProcedimientoAplicado nuevoProcedimiento)
        {
            if (nuevoProcedimiento == null)
                return BadRequest("Procedimiento inválido.");

            // Validar existencia de la mascota
            var mascotaExiste = _contexto.Mascotas.Any(m => m.id == nuevoProcedimiento.idMascota);
            if (!mascotaExiste)
                return BadRequest($"La mascota con id {nuevoProcedimiento.idMascota} no existe.");

            // Validar existencia del procedimiento
            var procedimientoExiste = _contexto.Procedimientos.Any(p => p.id == nuevoProcedimiento.idProcedimiento);
            if (!procedimientoExiste)
                return BadRequest($"El procedimiento con id {nuevoProcedimiento.idProcedimiento} no existe.");

            // Validar duplicado
            var existente = _memoria.ObtenerPorId(nuevoProcedimiento.idProcedimientoAplicado);
            if (existente != null)
                return Conflict("Ya existe un procedimiento aplicado con ese ID.");

            _memoria.Agregar(nuevoProcedimiento);
            return CreatedAtAction(nameof(Get), new { id = nuevoProcedimiento.idProcedimientoAplicado }, nuevoProcedimiento);
        }

        // PUT: api/ProcedimientoAplicado/{id}
        [HttpPut("{id}")]
        public ActionResult<ProcedimientoAplicado> Put(int id, [FromBody] ProcedimientoAplicado procedimientoActualizado)
        {
            if (procedimientoActualizado == null || id != procedimientoActualizado.idProcedimientoAplicado)
                return BadRequest("ID no coincide.");

            // Validar existencia de la mascota
            var mascotaExiste = _contexto.Mascotas.Any(m => m.id == procedimientoActualizado.idMascota);
            if (!mascotaExiste)
                return BadRequest($"La mascota con id {procedimientoActualizado.idMascota} no existe.");

            // Validar existencia del procedimiento
            var procedimientoExiste = _contexto.Procedimientos.Any(p => p.id == procedimientoActualizado.idProcedimiento);
            if (!procedimientoExiste)
                return BadRequest($"El procedimiento con id {procedimientoActualizado.idProcedimiento} no existe.");

            var actualizado = _memoria.Editar(procedimientoActualizado);
            if (actualizado == null)
                return NotFound($"No se encontró un procedimiento aplicado con id {id}.");

            return Ok(actualizado);
        }

        // DELETE: api/ProcedimientoAplicado/{id}
        [HttpDelete("{id}")]
        public ActionResult<ProcedimientoAplicado> Delete(int id)
        {
            var eliminado = _memoria.Eliminar(id);
            if (eliminado == null)
                return NotFound($"No se encontró un procedimiento aplicado con id {id}.");

            return Ok(eliminado);
        }
    }
}
