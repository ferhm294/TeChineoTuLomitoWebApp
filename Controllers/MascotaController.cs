using Microsoft.AspNetCore.Mvc;
using MVC_TeChineoTuLomito.Models;
using MVC_TeChineoTuLomito.Servicios.Mascota;

namespace MVC_TeChineoTuLomito.Controllers
{
    public class MascotaController : Controller
    {
        private readonly IServicioMascota servicioMascota;

        public MascotaController(IServicioMascota servicioMascota)
        {
            this.servicioMascota = servicioMascota;
        }

        // GET: MascotaController
        public async Task<ActionResult> Index(string searchString)
        {
            var mascotas = await servicioMascota.Get();

            if (!string.IsNullOrEmpty(searchString))
            {
                mascotas = mascotas
                    .Where(m => m.especie.Contains(searchString, StringComparison.OrdinalIgnoreCase)
                             || m.nombreMascota.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(mascotas);
        }

        // GET: MascotaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var mascota = await servicioMascota.BuscarMas(id);
            return View(mascota);
        }

        // GET: MascotaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MascotaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Mascota mascotaACrear)
        {
            try
            {
                await servicioMascota.Guardar(mascotaACrear);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MascotaController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var mascota = await servicioMascota.BuscarMas(id);
            return View(mascota);
        }

        // POST: MascotaController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Mascota mascotaEditada)
        {
            try
            {
                await servicioMascota.EditarMas(mascotaEditada);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MascotaController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var mascota = await servicioMascota.BuscarMas(id);
            return View(mascota);
        }

        // POST: MascotaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Mascota mascota)
        {
            try
            {
                await servicioMascota.EliminarMas(mascota.id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
