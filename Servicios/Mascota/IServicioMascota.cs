using ModeloMascota = MVC_TeChineoTuLomito.Models.Mascota;

namespace MVC_TeChineoTuLomito.Servicios.Mascota
{
    public interface IServicioMascota
    {
        Task<List<ModeloMascota>> Get();
        Task<bool> Guardar(ModeloMascota obj_mascota);
        Task<ModeloMascota> BuscarMas(int id);
        Task<bool> EditarMas(ModeloMascota obj_mascota);
        Task<bool> EliminarMas(int id);
    }
}
