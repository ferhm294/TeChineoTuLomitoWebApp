using Microsoft.AspNetCore.Mvc;
using MVC_TeChineoTuLomito.Models;
using MVC_TeChineoTuLomito.Servicios.Procedimiento;

namespace MVC_TeChineoTuLomito.Controllers
{
    public class ProcedimientoController : Controller
    {
        private readonly IServicioProcedimiento servicioProcedimiento;

        public ProcedimientoController(IServicioProcedimiento servicioProcedimiento)
        {
            this.servicioProcedimiento = servicioProcedimiento;
        }

        // GET: ProcedimientoController
        public async Task<ActionResult> Index(string searchString)
        {
            var procedimientos = await servicioProcedimiento.Get();

            if (!string.IsNullOrEmpty(searchString))
            {
                procedimientos = procedimientos
                    .Where(p => p.tipoProcedimiento.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(procedimientos);
        }

        // GET: ProcedimientoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var procedimiento = await servicioProcedimiento.BuscarPro(id);
            return View(procedimiento);
        }

        // GET: ProcedimientoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProcedimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Procedimiento procedimientoACrear)
        {
            try
            {
                await servicioProcedimiento.Guardar(procedimientoACrear);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProcedimientoController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var procedimiento = await servicioProcedimiento.BuscarPro(id);
            return View(procedimiento);
        }

        // POST: ProcedimientoController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Procedimiento procedimientoEditado)
        {
            try
            {
                await servicioProcedimiento.EditarPro(procedimientoEditado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProcedimientoController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var procedimiento = await servicioProcedimiento.BuscarPro(id);
            return View(procedimiento);
        }

        // POST: ProcedimientoController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Procedimiento procedimiento)
        {
            try
            {
                await servicioProcedimiento.EliminarPro(procedimiento.id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
