namespace MVC_TeChineoTuLomito.Models
{
    public class Cliente : Persona
    {
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string direccionExacta { get; set; }
        public string telefono { get; set; }
        public bool preferenciaContacto { get; set; } // true = llamada, false = mensaje de WhatsApp
    }
}
