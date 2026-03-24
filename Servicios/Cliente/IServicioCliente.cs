using ModeloCliente = MVC_TeChineoTuLomito.Models.Cliente;

namespace MVC_TeChineoTuLomito.Servicios.Cliente
{
    public interface IServicioCliente
    {
        Task<List<ModeloCliente>> Get();
        Task<bool> Guardar(ModeloCliente obj_cliente);
        Task<ModeloCliente> BuscarCli(string identificacion);
        Task<bool> EditarCli(ModeloCliente obj_cliente);
        Task<bool> EliminarCli(string identificacion);
    }
}
