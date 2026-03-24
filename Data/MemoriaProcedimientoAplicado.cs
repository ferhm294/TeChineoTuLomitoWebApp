using API_TeChineoTuLomito.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TeChineoTuLomito.Data
{
    public class MemoriaProcedimientoAplicado
    {
        private readonly DBContexto ElContexto;

        public MemoriaProcedimientoAplicado(DBContexto contexto)
        {
            ElContexto = contexto;
        }

        public List<ProcedimientoAplicado> ObtenerLista()
        {
            var lista = ElContexto.ProcedimientosAplicados
            .Include(pa => pa.Mascota)
            .Include(pa => pa.Procedimiento)
            .Select(pa => new ProcedimientoAplicado
            {
                idProcedimientoAplicado = pa.idProcedimientoAplicado,
                idMascota = pa.idMascota,
                idProcedimiento = pa.idProcedimiento,
                precioProcedimientoConImpuesto = pa.precioProcedimientoConImpuesto,
                estadoProcedimento = pa.estadoProcedimento,

                // Rellenar las propiedades NotMapped
                identificacionDueno = pa.Mascota.identificacionDueño,
                nombreMascota = pa.Mascota.nombreMascota,
                tipoProcedimientoAplicado = pa.Procedimiento.tipoProcedimiento
            })
            .ToList();


            return lista;
        }

        public ProcedimientoAplicado ObtenerPorId(int idProcedimientoAplicado)
        {
            return ElContexto.ProcedimientosAplicados
                             .FirstOrDefault(p => p.idProcedimientoAplicado == idProcedimientoAplicado);
        }

        public bool Agregar(ProcedimientoAplicado procedimiento)
        {
            // Validar que exista la mascota
            var mascota = ElContexto.Mascotas
                                    .FirstOrDefault(m => m.identificacionDueño == procedimiento.identificacionDueno
                                                      && m.nombreMascota == procedimiento.nombreMascota);
            if (mascota == null)
                return false;

            // Validar que exista el procedimiento
            var procBase = ElContexto.Procedimientos
                                     .FirstOrDefault(p => p.tipoProcedimiento == procedimiento.tipoProcedimientoAplicado);
            if (procBase == null)
                return false;

            // Calcular precio con impuesto
            procedimiento.precioProcedimientoConImpuesto = (Decimal) Math.Round(procBase.precio * 1.13, 2);

            ElContexto.ProcedimientosAplicados.Add(procedimiento);
            ElContexto.SaveChanges();
            return true;
        }

        public ProcedimientoAplicado Editar(ProcedimientoAplicado procedimientoActualizado)
        {
            var procedimiento = ElContexto.ProcedimientosAplicados
                                          .FirstOrDefault(p => p.idProcedimientoAplicado == procedimientoActualizado.idProcedimientoAplicado);
            if (procedimiento != null)
            {
                var mascota = ElContexto.Mascotas
                                        .FirstOrDefault(m => m.identificacionDueño == procedimientoActualizado.identificacionDueno
                                                          && m.nombreMascota == procedimientoActualizado.nombreMascota);
                if (mascota == null)
                    return null;

                var procBase = ElContexto.Procedimientos
                                         .FirstOrDefault(p => p.tipoProcedimiento == procedimientoActualizado.tipoProcedimientoAplicado);
                if (procBase == null)
                    return null;

                procedimiento.identificacionDueno = procedimientoActualizado.identificacionDueno;
                procedimiento.nombreMascota = procedimientoActualizado.nombreMascota;
                procedimiento.tipoProcedimientoAplicado = procedimientoActualizado.tipoProcedimientoAplicado;
                procedimiento.precioProcedimientoConImpuesto = (Decimal) Math.Round(procBase.precio * 1.13, 2);
                procedimiento.estadoProcedimento = procedimientoActualizado.estadoProcedimento;

                ElContexto.ProcedimientosAplicados.Update(procedimiento);
                ElContexto.SaveChanges();
            }
            return procedimiento;
        }

        public ProcedimientoAplicado Eliminar(int idProcedimientoAplicado)
        {
            var procedimiento = ElContexto.ProcedimientosAplicados
                                          .FirstOrDefault(p => p.idProcedimientoAplicado == idProcedimientoAplicado);
            if (procedimiento != null)
            {
                ElContexto.ProcedimientosAplicados.Remove(procedimiento);
                ElContexto.SaveChanges();
            }
            return procedimiento;
        }

        public bool EstaVacio()
        {
            return !ElContexto.ProcedimientosAplicados.Any();
        }

        private double CalcularPrecioConImpuesto(string tipo)
        {
            var procedimiento = ElContexto.Procedimientos
                                          .FirstOrDefault(p => p.tipoProcedimiento == tipo);

            return procedimiento == null ? 0.0 : Math.Round(procedimiento.precio * 1.13, 2);
        }
    }
}
