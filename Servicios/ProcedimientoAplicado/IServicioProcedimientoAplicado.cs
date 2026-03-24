using ModeloProcedimientoAplicado = MVC_TeChineoTuLomito.Models.ProcedimientoAplicado;

namespace MVC_TeChineoTuLomito.Servicios.ProcedimientoAplicado
{
    public interface IServicioProcedimientoAplicado
    {
        Task<List<ModeloProcedimientoAplicado>> Get();
        Task<bool> Guardar(ModeloProcedimientoAplicado obj_aplicado);
        Task<ModeloProcedimientoAplicado> BuscarPA(int idProcedimientoAplicado);
        Task<bool> EditarPA(ModeloProcedimientoAplicado obj_aplicado);
        Task<bool> EliminarPA(int idProcedimientoAplicado);
    }
}
