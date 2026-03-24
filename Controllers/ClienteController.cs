using Microsoft.AspNetCore.Mvc;
using API_TeChineoTuLomito.Data;
using API_TeChineoTuLomito.Models;

namespace API_TeChineoTuLomito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly MemoriaCliente _memoria;

        public ClienteController(DBContexto contexto)
        {
            _memoria = new MemoriaCliente(contexto);
        }

        // GET: api/Cliente
        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            return _memoria.ObtenerLista();
        }

        // GET: api/Cliente/{identificacion}
        [HttpGet("{identificacion}")]
        public ActionResult<Cliente> Get(string identificacion)
        {
            var cliente = _memoria.ObtenerPorIdentificacion(identificacion);
            if (cliente == null)
                return NotFound();
            return cliente;
        }

        // POST: api/Cliente
        [HttpPost]
        public ActionResult<Cliente> Post([FromBody] Cliente nuevoCliente)
        {
            if (nuevoCliente == null || string.IsNullOrEmpty(nuevoCliente.identificacion))
                return BadRequest("Cliente inválido o sin identificación.");

            var existente = _memoria.ObtenerPorIdentificacion(nuevoCliente.identificacion);
            if (existente != null)
                return Conflict("Ya existe un cliente con esa identificación.");

            _memoria.Agregar(nuevoCliente);
            return CreatedAtAction(nameof(Get), new { identificacion = nuevoCliente.identificacion }, nuevoCliente);
        }

        // PUT: api/Cliente/{identificacion}
        [HttpPut("{identificacion}")]
        public ActionResult<Cliente> Put(string identificacion, [FromBody] Cliente clienteActualizado)
        {
            if (clienteActualizado == null || identificacion != clienteActualizado.identificacion)
                return BadRequest("Identificación no coincide.");

            var actualizado = _memoria.Editar(clienteActualizado);
            if (actualizado == null)
                return NotFound();

            return Ok(actualizado);
        }

        // DELETE: api/Cliente/{identificacion}
        [HttpDelete("{identificacion}")]
        public ActionResult<Cliente> Delete(string identificacion)
        {
            var eliminado = _memoria.Eliminar(identificacion);
            if (eliminado == null)
                return NotFound();

            return Ok(eliminado);
        }
    }
}
