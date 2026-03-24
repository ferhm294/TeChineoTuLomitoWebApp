using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization; // necesario para [JsonIgnore]

namespace API_TeChineoTuLomito.Models
{
    [Table("Mascota", Schema = "TeChineoTuLomito_Schema")]
    public class Mascota
    {
        [Key]
        public int id { get; set; }

        // FK hacia Cliente (columna real en SQL: identificacionDueno)
        [Column("identificacionDueno")]
        public string identificacionDueño { get; set; }

        public string especie { get; set; }
        public string raza { get; set; }
        public int edad { get; set; }
        public string color { get; set; }

        // EF Core necesita mapping explícito si usas DateOnly
        public DateOnly ultimaFechaAtencion { get; set; }
        public DateOnly ultimaFechaVacunacion { get; set; }

        public string telefonoDueno { get; set; }
        public string emailDueno { get; set; }
        public string nombreMascota { get; set; }

        // Navegación: se ignora en JSON para que el front no tenga que enviarla
        [JsonIgnore]
        public Cliente? Cliente { get; set; }

        [JsonIgnore]
        public ICollection<ProcedimientoAplicado>? ProcedimientosAplicados { get; set; } = new List<ProcedimientoAplicado>();
    }
}
