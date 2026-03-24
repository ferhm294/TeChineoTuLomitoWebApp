using Newtonsoft.Json;
using System.Text;
using ModeloProcedimiento = MVC_TeChineoTuLomito.Models.Procedimiento;

namespace MVC_TeChineoTuLomito.Servicios.Procedimiento
{
    public class ServicioProcedimiento : IServicioProcedimiento
    {
        private readonly string _baseurl;

        public ServicioProcedimiento()
        {
            _baseurl = "http://localhost:5233/";
        }

        public async Task<List<ModeloProcedimiento>> Get()
        {
            List<ModeloProcedimiento> lista = new List<ModeloProcedimiento>();
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.GetAsync("api/Procedimiento");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<ModeloProcedimiento>>(json);
                lista = resultado ?? new List<ModeloProcedimiento>();
            }

            return lista;
        }

        public async Task<bool> Guardar(ModeloProcedimiento obj_procedimiento)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_procedimiento), Encoding.UTF8, "application/json");
            var response = await clienteHttp.PostAsync("api/Procedimiento", contenido);

            return response.IsSuccessStatusCode;
        }

        public async Task<ModeloProcedimiento> BuscarPro(int id)
        {
            ModeloProcedimiento procedimientoEncontrado = null;
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.GetAsync($"api/Procedimiento/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                procedimientoEncontrado = JsonConvert.DeserializeObject<ModeloProcedimiento>(json);
            }

            return procedimientoEncontrado;
        }

        public async Task<bool> EditarPro(ModeloProcedimiento obj_procedimiento)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_procedimiento), Encoding.UTF8, "application/json");
            var response = await clienteHttp.PutAsync($"api/Procedimiento/{obj_procedimiento.id}", contenido);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarPro(int id)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.DeleteAsync($"api/Procedimiento/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
