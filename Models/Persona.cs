using System.ComponentModel.DataAnnotations;

namespace API_TeChineoTuLomito.Models
{
    public class Persona
    {
        [Key] // Marca esta propiedad como la clave primaria
        public string identificacion { get; set; }

        public string nombreCompleto { get; set; }
    }
}
