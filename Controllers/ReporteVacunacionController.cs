using Microsoft.AspNetCore.Mvc;
using MVC_TeChineoTuLomito.Models;
using MVC_TeChineoTuLomito.Servicios.ReporteVacunacion;

namespace MVC_TeChineoTuLomito.Controllers
{
    public class ReporteVacunacionController : Controller
    {
        private readonly IServicioReporteVacunacion servicioReporte;

        public ReporteVacunacionController(IServicioReporteVacunacion servicioReporte)
        {
            this.servicioReporte = servicioReporte;
        }

        // GET: ReporteVacunacion/Index
        public async Task<ActionResult> Index()
        {
            var clientes = await servicioReporte.GetClientesConVacunaPendiente();
            return View(clientes);
        }

        // GET: ReporteVacunacion/Detalles/{identificacion}
        public async Task<ActionResult> Detalles(string identificacion)
        {
            var cliente = await servicioReporte.BuscarCliente(identificacion);
            return View(cliente);
        }
    }
}
