using Newtonsoft.Json;
using System.Text;
using ModeloCliente = MVC_TeChineoTuLomito.Models.Cliente;

namespace MVC_TeChineoTuLomito.Servicios.Cliente
{
    public class ServicioCliente : IServicioCliente
    {
        private readonly string _baseurl;

        public ServicioCliente()
        {
            _baseurl = "http://localhost:5233/";
        }

        public async Task<List<ModeloCliente>> Get()
        {
            List<ModeloCliente> lista = new List<ModeloCliente>();
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.GetAsync("api/Cliente");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<ModeloCliente>>(json);
                lista = resultado ?? new List<ModeloCliente>();
            }

            return lista;
        }

        public async Task<bool> Guardar(ModeloCliente obj_cliente)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_cliente), Encoding.UTF8, "application/json");
            var response = await clienteHttp.PostAsync("api/Cliente", contenido);

            return response.IsSuccessStatusCode;
        }

        public async Task<ModeloCliente> BuscarCli(string identificacion)
        {
            ModeloCliente clienteEncontrado = null;
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.GetAsync($"api/Cliente/{identificacion}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                clienteEncontrado = JsonConvert.DeserializeObject<ModeloCliente>(json);
            }

            return clienteEncontrado;
        }

        public async Task<bool> EditarCli(ModeloCliente obj_cliente)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_cliente), Encoding.UTF8, "application/json");
            var response = await clienteHttp.PutAsync($"api/Cliente/{obj_cliente.identificacion}", contenido);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarCli(string identificacion)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.DeleteAsync($"api/Cliente/{identificacion}");

            return response.IsSuccessStatusCode;
        }
    }
}
