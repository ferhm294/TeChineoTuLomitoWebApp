using API_TeChineoTuLomito.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TeChineoTuLomito.Data
{
    public class MemoriaProcedimiento
    {
        private readonly DBContexto ElContexto;

        public MemoriaProcedimiento(DBContexto contexto)
        {
            ElContexto = contexto;
        }

        public List<Procedimiento> ObtenerLista()
        {
            return ElContexto.Procedimientos.ToList();
        }

        public Procedimiento ObtenerPorId(int id)
        {
            return ElContexto.Procedimientos
                             .FirstOrDefault(p => p.id == id);
        }

        public bool Agregar(Procedimiento procedimiento)
        {
            ElContexto.Procedimientos.Add(procedimiento);
            ElContexto.SaveChanges();
            return true;
        }

        public Procedimiento Editar(Procedimiento procedimientoActualizado)
        {
            var procedimiento = ElContexto.Procedimientos
                                          .FirstOrDefault(p => p.id == procedimientoActualizado.id);
            if (procedimiento != null)
            {
                ElContexto.Entry(procedimiento).CurrentValues.SetValues(procedimientoActualizado);
                ElContexto.SaveChanges();
            }
            return procedimiento;
        }

        public Procedimiento Eliminar(int id)
        {
            var procedimiento = ElContexto.Procedimientos
                                          .FirstOrDefault(p => p.id == id);
            if (procedimiento != null)
            {
                ElContexto.Procedimientos.Remove(procedimiento);
                ElContexto.SaveChanges();
            }
            return procedimiento;
        }

        public bool EstaVacio()
        {
            return !ElContexto.Procedimientos.Any();
        }
    }
}
