namespace MVC_TeChineoTuLomito.Models
{
    public class ProcedimientoAplicado
    {
        public int idProcedimientoAplicado { get; set; }
        public string identificacionDueno { get; set; }
        public string nombreMascota { get; set; }
        public string tipoProcedimientoAplicado { get; set; }
        public double precioProcedimientoConImpuesto { get; set; }
        public string estadoProcedimento { get; set; }
    }
}