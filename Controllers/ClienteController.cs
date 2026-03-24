using Microsoft.AspNetCore.Mvc;
using MVC_TeChineoTuLomito.Models;
using MVC_TeChineoTuLomito.Servicios.Cliente;

namespace MVC_TeChineoTuLomito.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IServicioCliente servicioCliente;

        public ClienteController(IServicioCliente servicioCliente)
        {
            this.servicioCliente = servicioCliente;
        }

        // GET: ClienteController
        public async Task<ActionResult> Index(string searchString)
        {
            var clientes = await servicioCliente.Get();

            if (!string.IsNullOrEmpty(searchString))
            {
                clientes = clientes
                    .Where(c => c.nombreCompleto.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return View(clientes);
        }

        // GET: ClienteController/Details/{identificacion}
        public async Task<ActionResult> Details(string identificacion)
        {
            var cliente = await servicioCliente.BuscarCli(identificacion);
            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cliente clienteACrear)
        {
            try
            {
                if (clienteACrear != null)
                {
                    await servicioCliente.Guardar(clienteACrear);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/{identificacion}
        public async Task<ActionResult> Edit(string identificacion)
        {
            var cliente = await servicioCliente.BuscarCli(identificacion);
            return View(cliente);
        }

        // POST: ClienteController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Cliente clienteEditado)
        {
            try
            {
                await servicioCliente.EditarCli(clienteEditado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/{identificacion}
        public async Task<ActionResult> Delete(string identificacion)
        {
            var cliente = await servicioCliente.BuscarCli(identificacion);
            return View(cliente);
        }

        // POST: ClienteController/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Cliente cliente)
        {
            try
            {
                await servicioCliente.EliminarCli(cliente.identificacion);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
