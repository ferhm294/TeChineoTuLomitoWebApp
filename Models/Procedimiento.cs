using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_TeChineoTuLomito.Models
{
    [Table("Procedimiento", Schema = "TeChineoTuLomito_Schema")]
    public class Procedimiento
    {
        [Key]
        public int id { get; set; }

        public string tipoProcedimiento { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }

        // Propiedad de navegación inversa
        public ICollection<ProcedimientoAplicado> ProcedimientosAplicados { get; set; } = new List<ProcedimientoAplicado>();
    }
}
