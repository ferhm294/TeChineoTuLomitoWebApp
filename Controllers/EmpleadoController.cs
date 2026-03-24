using Microsoft.AspNetCore.Mvc;
using MVC_TeChineoTuLomito.Models;
using MVC_TeChineoTuLomito.Servicios.Empleado;

namespace MVC_TeChineoTuLomito.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly IServicioEmpleado servicioEmpleado;

        public EmpleadoController(IServicioEmpleado servicioEmpleado)
        {
            this.servicioEmpleado = servicioEmpleado;
        }

        // GET: EmpleadoController
        public async Task<ActionResult> Index(string searchString)
        {
            var empleados = await servicioEmpleado.Get();

            if (!string.IsNullOrEmpty(searchString))
            {
                empleados = empleados
                    .Where(e => e.nombreCompleto.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(empleados);
        }

        // GET: EmpleadoController/Details/{identificacion}
        public async Task<ActionResult> Details(string identificacion)
        {
            var empleado = await servicioEmpleado.BuscarEmp(identificacion);
            return View(empleado);
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Empleado empleadoACrear)
        {
            try
            {
                if (empleadoACrear != null)
                {
                    await servicioEmpleado.Guardar(empleadoACrear);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Edit/{identificacion}
        public async Task<ActionResult> Edit(string identificacion)
        {
            var empleado = await servicioEmpleado.BuscarEmp(identificacion);
            return View(empleado);
        }

        // POST: EmpleadoController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Empleado empleadoEditado)
        {
            try
            {
                await servicioEmpleado.EditarEmp(empleadoEditado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Delete/{identificacion}
        public async Task<ActionResult> Delete(string identificacion)
        {
            var empleado = await servicioEmpleado.BuscarEmp(identificacion);
            return View(empleado);
        }

        // POST: EmpleadoController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Empleado empleado)
        {
            try
            {
                await servicioEmpleado.EliminarEmp(empleado.identificacion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
