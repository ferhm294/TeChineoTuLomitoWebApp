using Newtonsoft.Json;
using System.Text;
using ModeloEmpleado = MVC_TeChineoTuLomito.Models.Empleado;

namespace MVC_TeChineoTuLomito.Servicios.Empleado
{
    public class ServicioEmpleado : IServicioEmpleado
    {
        private readonly string _baseurl;

        public ServicioEmpleado()
        {
            _baseurl = "http://localhost:5233/";
        }

        public async Task<List<ModeloEmpleado>> Get()
        {
            List<ModeloEmpleado> lista = new List<ModeloEmpleado>();
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.GetAsync("api/Empleado");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<ModeloEmpleado>>(json);
                lista = resultado ?? new List<ModeloEmpleado>();
            }

            return lista;
        }

        public async Task<bool> Guardar(ModeloEmpleado obj_empleado)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_empleado), Encoding.UTF8, "application/json");
            var response = await clienteHttp.PostAsync("api/Empleado", contenido);

            return response.IsSuccessStatusCode;
        }

        public async Task<ModeloEmpleado> BuscarEmp(string identificacion)
        {
            ModeloEmpleado empleadoEncontrado = null;
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.GetAsync($"api/Empleado/{identificacion}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                empleadoEncontrado = JsonConvert.DeserializeObject<ModeloEmpleado>(json);
            }

            return empleadoEncontrado;
        }

        public async Task<bool> EditarEmp(ModeloEmpleado obj_empleado)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_empleado), Encoding.UTF8, "application/json");
            var response = await clienteHttp.PutAsync($"api/Empleado/{obj_empleado.identificacion}", contenido);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarEmp(string identificacion)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.DeleteAsync($"api/Empleado/{identificacion}");

            return response.IsSuccessStatusCode;
        }
    }
}
