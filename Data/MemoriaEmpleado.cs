using API_TeChineoTuLomito.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TeChineoTuLomito.Data
{
    public class MemoriaEmpleado
    {
        private readonly DBContexto ElContexto;

        public MemoriaEmpleado(DBContexto contexto)
        {
            ElContexto = contexto;
        }

        public List<Empleado> ObtenerLista()
        {
            return ElContexto.Empleados.ToList();
        }

        public Empleado ObtenerPorIdentificacion(string identificacion)
        {
            return ElContexto.Empleados
                             .FirstOrDefault(e => e.identificacion == identificacion);
        }

        public bool Agregar(Empleado empleado)
        {
            ElContexto.Empleados.Add(empleado);
            ElContexto.SaveChanges();
            return true;
        }

        public Empleado Editar(Empleado empleadoActualizado)
        {
            var empleado = ElContexto.Empleados
                                     .FirstOrDefault(e => e.identificacion == empleadoActualizado.identificacion);
            if (empleado != null)
            {
                ElContexto.Entry(empleado).CurrentValues.SetValues(empleadoActualizado);
                ElContexto.SaveChanges();
            }
            return empleado;
        }

        public Empleado Eliminar(string identificacion)
        {
            var empleado = ElContexto.Empleados
                                     .FirstOrDefault(e => e.identificacion == identificacion);
            if (empleado != null)
            {
                ElContexto.Empleados.Remove(empleado);
                ElContexto.SaveChanges();
            }
            return empleado;
        }

        public bool EstaVacio()
        {
            return !ElContexto.Empleados.Any();
        }
    }
}
