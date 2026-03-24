using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_TeChineoTuLomito.Models
{
    [Table("ProcedimientoAplicado", Schema = "TeChineoTuLomito_Schema")]
    public class ProcedimientoAplicado
    {
        [Key]
        public int idProcedimientoAplicado { get; set; }

        // FK hacia Mascota: opcional y no se pide en el JSON
        [Column("idMascota")]
        [JsonIgnore]
        public int? idMascota { get; set; }

        // FK hacia Procedimiento: este sí lo manda el front
        [Column("idProcedimiento")]
        public int idProcedimiento { get; set; }

        // Campo calculado: ignorado en el JSON
        [JsonIgnore]
        public decimal? precioProcedimientoConImpuesto { get; set; }

        public string estadoProcedimento { get; set; }

        // Propiedades que tu API y front ya usan (no existen en la BD)
        [NotMapped]
        public string identificacionDueno { get; set; }

        [NotMapped]
        public string nombreMascota { get; set; }

        [NotMapped]
        public string tipoProcedimientoAplicado { get; set; }

        // Navegación opcional (ignorada en JSON)
        [JsonIgnore]
        public Mascota? Mascota { get; set; }

        [JsonIgnore]
        public Procedimiento? Procedimiento { get; set; }
    }
}
