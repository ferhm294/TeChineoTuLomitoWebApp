using Newtonsoft.Json;
using System.Text;
using ModeloProcedimientoAplicado = MVC_TeChineoTuLomito.Models.ProcedimientoAplicado;

namespace MVC_TeChineoTuLomito.Servicios.ProcedimientoAplicado
{
    public class ServicioProcedimientoAplicado : IServicioProcedimientoAplicado
    {
        private readonly string _baseurl;

        public ServicioProcedimientoAplicado()
        {
            _baseurl = "http://localhost:5233/";
        }

        public async Task<List<ModeloProcedimientoAplicado>> Get()
        {
            List<ModeloProcedimientoAplicado> lista = new List<ModeloProcedimientoAplicado>();
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.GetAsync("api/ProcedimientoAplicado");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<ModeloProcedimientoAplicado>>(json);
                lista = resultado ?? new List<ModeloProcedimientoAplicado>();
            }

            return lista;
        }

        public async Task<bool> Guardar(ModeloProcedimientoAplicado obj_aplicado)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_aplicado), Encoding.UTF8, "application/json");
            var response = await clienteHttp.PostAsync("api/ProcedimientoAplicado", contenido);

            return response.IsSuccessStatusCode;
        }

        public async Task<ModeloProcedimientoAplicado> BuscarPA(int idProcedimientoAplicado)
        {
            ModeloProcedimientoAplicado encontrado = null;
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.GetAsync($"api/ProcedimientoAplicado/{idProcedimientoAplicado}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                encontrado = JsonConvert.DeserializeObject<ModeloProcedimientoAplicado>(json);
            }

            return encontrado;
        }

        public async Task<bool> EditarPA(ModeloProcedimientoAplicado obj_aplicado)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_aplicado), Encoding.UTF8, "application/json");
            var response = await clienteHttp.PutAsync($"api/ProcedimientoAplicado/{obj_aplicado.idProcedimientoAplicado}", contenido);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarPA(int idProcedimientoAplicado)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.DeleteAsync($"api/ProcedimientoAplicado/{idProcedimientoAplicado}");

            return response.IsSuccessStatusCode;
        }
    }
}
