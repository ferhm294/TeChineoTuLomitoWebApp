namespace MVC_TeChineoTuLomito.Models
{
    public class Mascota
    {
        public int id { get; set; }
        public string identificacionDueño { get; set; }
        public string especie { get; set; }
        public string raza { get; set; }
        public int edad { get; set; }
        public string color { get; set; }
        public DateOnly ultimaFechaAtencion { get; set; }
        public DateOnly ultimaFechaVacunacion { get; set; }
        public string telefonoDueno { get; set; }
        public string emailDueno { get; set; }
        public string nombreMascota { get; set; }
    }
}
