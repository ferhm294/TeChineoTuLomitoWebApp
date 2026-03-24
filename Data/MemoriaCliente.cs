using API_TeChineoTuLomito.Models;
using Microsoft.EntityFrameworkCore;

namespace API_TeChineoTuLomito.Data
{
    public class MemoriaCliente
    {
        private readonly DBContexto ElContexto;

        public MemoriaCliente(DBContexto contexto)
        {
            ElContexto = contexto;
        }

        public List<Cliente> ObtenerLista()
        {
            return ElContexto.Clientes.ToList();
        }

        public Cliente ObtenerPorIdentificacion(string identificacion)
        {
            return ElContexto.Clientes
                             .FirstOrDefault(c => c.identificacion == identificacion);
        }

        public bool Agregar(Cliente cliente)
        {
            ElContexto.Clientes.Add(cliente);
            ElContexto.SaveChanges();
            return true;
        }

        public Cliente Editar(Cliente clienteActualizado)
        {
            var cliente = ElContexto.Clientes
                                    .FirstOrDefault(c => c.identificacion == clienteActualizado.identificacion);
            if (cliente != null)
            {
                ElContexto.Entry(cliente).CurrentValues.SetValues(clienteActualizado);
                ElContexto.SaveChanges();
            }
            return cliente;
        }

        public Cliente Eliminar(string identificacion)
        {
            var cliente = ElContexto.Clientes
                                    .FirstOrDefault(c => c.identificacion == identificacion);
            if (cliente != null)
            {
                ElContexto.Clientes.Remove(cliente);
                ElContexto.SaveChanges();
            }
            return cliente;
        }

        public bool EstaVacio()
        {
            return !ElContexto.Clientes.Any();
        }
    }
}
