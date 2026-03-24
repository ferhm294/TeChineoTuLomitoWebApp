using Microsoft.AspNetCore.Mvc;
using MVC_TeChineoTuLomito.Models;
using MVC_TeChineoTuLomito.Servicios.ProcedimientoAplicado;
using MVC_TeChineoTuLomito.Servicios.Procedimiento;

namespace MVC_TeChineoTuLomito.Controllers
{
    public class ProcedimientoAplicadoController : Controller
    {
        private readonly IServicioProcedimientoAplicado servicioAplicado;
        private readonly IServicioProcedimiento servicioProcedimiento;
        private static readonly List<string> estados = new List<string> { "en proceso", "facturado", "agendado" };

        public ProcedimientoAplicadoController(IServicioProcedimientoAplicado servicioAplicado, IServicioProcedimiento servicioProcedimiento)
        {
            this.servicioAplicado = servicioAplicado;
            this.servicioProcedimiento = servicioProcedimiento;
        }

        private async Task<double> CalcularPrecioConImpuesto(string tipo)
        {
            var procedimientos = await servicioProcedimiento.Get();
            var procedimiento = procedimientos.FirstOrDefault(p => p.tipoProcedimiento == tipo);
            return procedimiento == null ? 0.0 : procedimiento.precio * 1.13;
        }

        public async Task<ActionResult> Index(string searchString)
        {
            var lista = await servicioAplicado.Get();

            if (!string.IsNullOrEmpty(searchString))
            {
                lista = lista
                    .Where(p => p.nombreMascota.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(lista);
        }

        public async Task<ActionResult> Details(int id)
        {
            var procedimiento = await servicioAplicado.BuscarPA(id);
            return View(procedimiento);
        }

        public async Task<ActionResult> Create()
        {
            var disponibles = await servicioProcedimiento.Get();
            ViewBag.ProcedimientosDisponibles = disponibles.Select(p => p.tipoProcedimiento).ToList();
            ViewBag.EstadosDisponibles = estados;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProcedimientoAplicado nuevo)
        {
            try
            {
                nuevo.precioProcedimientoConImpuesto = await CalcularPrecioConImpuesto(nuevo.tipoProcedimientoAplicado);
                await servicioAplicado.Guardar(nuevo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var disponibles = await servicioProcedimiento.Get();
                ViewBag.ProcedimientosDisponibles = disponibles.Select(p => p.tipoProcedimiento).ToList();
                ViewBag.EstadosDisponibles = estados;
                return View(nuevo);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var procedimiento = await servicioAplicado.BuscarPA(id);
            var disponibles = await servicioProcedimiento.Get();
            ViewBag.ProcedimientosDisponibles = disponibles.Select(p => p.tipoProcedimiento).ToList();
            ViewBag.EstadosDisponibles = estados;
            return View(procedimiento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProcedimientoAplicado editado)
        {
            try
            {
                editado.precioProcedimientoConImpuesto = await CalcularPrecioConImpuesto(editado.tipoProcedimientoAplicado);
                await servicioAplicado.EditarPA(editado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var disponibles = await servicioProcedimiento.Get();
                ViewBag.ProcedimientosDisponibles = disponibles.Select(p => p.tipoProcedimiento).ToList();
                ViewBag.EstadosDisponibles = estados;
                return View(editado);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var procedimiento = await servicioAplicado.BuscarPA(id);
            return View(procedimiento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(ProcedimientoAplicado procedimiento)
        {
            try
            {
                await servicioAplicado.EliminarPA(procedimiento.idProcedimientoAplicado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
