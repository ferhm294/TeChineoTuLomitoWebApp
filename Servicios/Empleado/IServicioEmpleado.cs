using ModeloEmpleado = MVC_TeChineoTuLomito.Models.Empleado;

namespace MVC_TeChineoTuLomito.Servicios.Empleado
{
    public interface IServicioEmpleado
    {
        Task<List<ModeloEmpleado>> Get();
        Task<bool> Guardar(ModeloEmpleado obj_empleado);
        Task<ModeloEmpleado> BuscarEmp(string identificacion);
        Task<bool> EditarEmp(ModeloEmpleado obj_empleado);
        Task<bool> EliminarEmp(string identificacion);
    }
}
