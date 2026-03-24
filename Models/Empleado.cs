using System.ComponentModel.DataAnnotations.Schema;

namespace API_TeChineoTuLomito.Models
{
    [Table("Empleado", Schema = "TeChineoTuLomito_Schema")] // nombre exacto de la tabla en SQL Server
    public class Empleado : Persona
    {
        // La PK está en Persona: identificacion con [Key]

        public DateOnly fechaNacimiento { get; set; }
        public DateOnly fechaContratacion { get; set; }
        public double salarioXDia { get; set; }
        public DateOnly fechaRetiro { get; set; }
        public string tipoEmpleado { get; set; }
    }
}
