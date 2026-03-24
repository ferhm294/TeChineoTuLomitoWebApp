using Newtonsoft.Json;
using ModeloCliente = MVC_TeChineoTuLomito.Models.Cliente;

namespace MVC_TeChineoTuLomito.Servicios.ReporteVacunacion
{
    public class ServicioReporteVacunacion : IServicioReporteVacunacion
    {
        private readonly string _baseurl;

        public ServicioReporteVacunacion()
        {
            _baseurl = "http://localhost:5233/";
        }

        public async Task<List<ModeloCliente>> GetClientesConVacunaPendiente()
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.GetAsync("api/Reporte/VacunacionProximaSemana");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<ModeloCliente>>(json);
                return resultado ?? new List<ModeloCliente>();
            }

            return new List<ModeloCliente>();
        }

        public async Task<ModeloCliente> BuscarCliente(string identificacion)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.GetAsync($"api/Cliente/{identificacion}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ModeloCliente>(json);
            }

            return null;
        }
    }
}
