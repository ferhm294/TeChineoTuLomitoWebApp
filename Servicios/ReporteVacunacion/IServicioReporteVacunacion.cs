using ModeloCliente = MVC_TeChineoTuLomito.Models.Cliente;

namespace MVC_TeChineoTuLomito.Servicios.ReporteVacunacion
{
    public interface IServicioReporteVacunacion
    {
        Task<List<ModeloCliente>> GetClientesConVacunaPendiente();
        Task<ModeloCliente> BuscarCliente(string identificacion);
    }
}
