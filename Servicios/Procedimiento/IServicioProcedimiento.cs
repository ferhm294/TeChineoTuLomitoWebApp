using ModeloProcedimiento = MVC_TeChineoTuLomito.Models.Procedimiento;

namespace MVC_TeChineoTuLomito.Servicios.Procedimiento
{
    public interface IServicioProcedimiento
    {
        Task<List<ModeloProcedimiento>> Get();
        Task<bool> Guardar(ModeloProcedimiento obj_procedimiento);
        Task<ModeloProcedimiento> BuscarPro(int id);
        Task<bool> EditarPro(ModeloProcedimiento obj_procedimiento);
        Task<bool> EliminarPro(int id);
    }
}
