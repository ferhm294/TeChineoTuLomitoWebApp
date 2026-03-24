using API_TeChineoTuLomito.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TeChineoTuLomito.Data
{
    public class MemoriaMascota
    {
        private readonly DBContexto ElContexto;

        public MemoriaMascota(DBContexto contexto)
        {
            ElContexto = contexto;
        }

        // Devuelve todas las mascotas, lista vacía si no hay registros
        public List<Mascota> ObtenerLista()
        {
            return ElContexto.Mascotas
                             .Include(m => m.Cliente) // opcional: carga el dueño si existe
                             .ToList();
        }

        // Devuelve una mascota por ID, null si no existe
        public Mascota ObtenerPorId(int id)
        {
            return ElContexto.Mascotas
                             .Include(m => m.Cliente) // opcional: carga el dueño si existe
                             .FirstOrDefault(m => m.id == id);
        }

        // Agrega una mascota validando que el dueño exista
        public bool Agregar(Mascota mascota)
        {
            var existeDueno = ElContexto.Clientes
                                        .Any(c => c.identificacion == mascota.identificacionDueño);

            if (!existeDueno)
            {
                // No se agrega porque no existe el dueño
                return false;
            }

            ElContexto.Mascotas.Add(mascota);
            ElContexto.SaveChanges();
            return true;
        }

        // Edita una mascota si existe
        public Mascota Editar(Mascota mascotaActualizada)
        {
            var mascota = ElContexto.Mascotas
                                    .FirstOrDefault(m => m.id == mascotaActualizada.id);
            if (mascota != null)
            {
                ElContexto.Entry(mascota).CurrentValues.SetValues(mascotaActualizada);
                ElContexto.SaveChanges();
            }
            return mascota;
        }

        // Elimina una mascota si existe
        public Mascota Eliminar(int id)
        {
            var mascota = ElContexto.Mascotas
                                    .FirstOrDefault(m => m.id == id);
            if (mascota != null)
            {
                ElContexto.Mascotas.Remove(mascota);
                ElContexto.SaveChanges();
            }
            return mascota;
        }

        // Devuelve true si la tabla está vacía
        public bool EstaVacio()
        {
            return !ElContexto.Mascotas.Any();
        }
    }
}
