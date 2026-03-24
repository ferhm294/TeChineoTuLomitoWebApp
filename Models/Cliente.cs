using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization; // necesario para [JsonIgnore]

namespace API_TeChineoTuLomito.Models
{
    [Table("Cliente", Schema = "TeChineoTuLomito_Schema")]
    public class Cliente : Persona
    {
        // La PK está en Persona: identificacion con [Key]

        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string direccionExacta { get; set; }
        public string telefono { get; set; }
        public bool preferenciaContacto { get; set; } // true = llamada, false = mensaje de WhatsApp

        // Propiedad de navegación inversa
        // Se ignora en JSON para que el front no tenga que enviarla
        [JsonIgnore]
        public ICollection<Mascota>? Mascotas { get; set; } = new List<Mascota>();
    }
}
