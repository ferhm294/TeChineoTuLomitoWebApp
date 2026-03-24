using Microsoft.AspNetCore.Mvc;
using API_TeChineoTuLomito.Models;
using API_TeChineoTuLomito.Data;

namespace API_TeChineoTuLomito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly MemoriaMascota _memoria;

        public MascotaController(DBContexto contexto)
        {
            _memoria = new MemoriaMascota(contexto);
        }

        // GET: api/Mascota
        [HttpGet]
        public ActionResult<List<Mascota>> Get()
        {
            return _memoria.ObtenerLista();
        }

        // GET: api/Mascota/{id}
        [HttpGet("{id}")]
        public ActionResult<Mascota> Get(int id)
        {
            var mascota = _memoria.ObtenerPorId(id);
            if (mascota == null)
                return NotFound();
            return mascota;
        }

        // POST: api/Mascota
        [HttpPost]
        public ActionResult<Mascota> Post([FromBody] Mascota nuevaMascota)
        {
            if (nuevaMascota == null)
                return BadRequest("Mascota inválida.");

            var existente = _memoria.ObtenerPorId(nuevaMascota.id);
            if (existente != null)
                return Conflict("Ya existe una mascota con ese ID.");

            _memoria.Agregar(nuevaMascota);
            return CreatedAtAction(nameof(Get), new { id = nuevaMascota.id }, nuevaMascota);
        }

        // PUT: api/Mascota/{id}
        [HttpPut("{id}")]
        public ActionResult<Mascota> Put(int id, [FromBody] Mascota mascotaActualizada)
        {
            if (mascotaActualizada == null || id != mascotaActualizada.id)
                return BadRequest("ID no coincide.");

            var actualizado = _memoria.Editar(mascotaActualizada);
            if (actualizado == null)
                return NotFound();

            return Ok(actualizado);
        }

        // DELETE: api/Mascota/{id}
        [HttpDelete("{id}")]
        public ActionResult<Mascota> Delete(int id)
        {
            var eliminado = _memoria.Eliminar(id);
            if (eliminado == null)
                return NotFound();

            return Ok(eliminado);
        }
    }
}
