namespace MVC_TeChineoTuLomito.Models
{
    public class Empleado : Persona
    {
        public DateOnly fechaNacimiento { get; set; }
        public DateOnly fechaContratacion { get; set; }
        public double salarioXDia { get; set; }
        public DateOnly fechaRetiro { get; set; }
        public string tipoEmpleado { get; set; }
    }
}