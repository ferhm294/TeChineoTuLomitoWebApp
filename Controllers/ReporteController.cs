using Microsoft.AspNetCore.Mvc;
using API_TeChineoTuLomito.Data;
using API_TeChineoTuLomito.Models;

namespace API_TeChineoTuLomito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly MemoriaMascota _memoriaMascota;
        private readonly MemoriaCliente _memoriaCliente;

        public ReporteController(DBContexto contexto)
        {
            _memoriaMascota = new MemoriaMascota(contexto);
            _memoriaCliente = new MemoriaCliente(contexto);
        }

        // GET: api/Reporte/VacunacionProximaSemana
        [HttpGet("VacunacionProximaSemana")]
        public ActionResult<List<Cliente>> GetClientesConVacunaPendiente()
        {
            var hoy = DateOnly.FromDateTime(DateTime.Today);
            var inicioSemana = hoy.AddDays(7 - (int)hoy.DayOfWeek); // próximo lunes
            var finSemana = inicioSemana.AddDays(6); // próximo domingo

            var mascotasPendientes = _memoriaMascota.ObtenerLista()
                .Where(m =>
                    m.ultimaFechaVacunacion == inicioSemana.AddYears(-1) ||
                    m.ultimaFechaVacunacion == finSemana.AddYears(-1) ||
                    (m.ultimaFechaVacunacion > inicioSemana.AddYears(-1) && m.ultimaFechaVacunacion < finSemana.AddYears(-1))
                )
                .ToList();

            var clientes = new List<Cliente>();

            foreach (var mascota in mascotasPendientes)
            {
                var cliente = _memoriaCliente.ObtenerPorIdentificacion(mascota.identificacionDueño);
                if (cliente != null && !clientes.Any(c => c.identificacion == cliente.identificacion))
                {
                    clientes.Add(cliente);
                }
            }

            return clientes;
        }
    }
}
