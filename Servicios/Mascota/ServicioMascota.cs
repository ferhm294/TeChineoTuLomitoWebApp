using Newtonsoft.Json;
using System.Text;
using ModeloMascota = MVC_TeChineoTuLomito.Models.Mascota;

namespace MVC_TeChineoTuLomito.Servicios.Mascota
{
    public class ServicioMascota : IServicioMascota
    {
        private readonly string _baseurl;

        public ServicioMascota()
        {
            _baseurl = "http://localhost:5233/";
        }

        public async Task<List<ModeloMascota>> Get()
        {
            List<ModeloMascota> lista = new List<ModeloMascota>();
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.GetAsync("api/Mascota");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<ModeloMascota>>(json);
                lista = resultado ?? new List<ModeloMascota>();
            }

            return lista;
        }

        public async Task<bool> Guardar(ModeloMascota obj_mascota)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_mascota), Encoding.UTF8, "application/json");
            var response = await clienteHttp.PostAsync("api/Mascota", contenido);

            return response.IsSuccessStatusCode;
        }

        public async Task<ModeloMascota> BuscarMas(int id)
        {
            ModeloMascota mascotaEncontrada = null;
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.GetAsync($"api/Mascota/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                mascotaEncontrada = JsonConvert.DeserializeObject<ModeloMascota>(json);
            }

            return mascotaEncontrada;
        }

        public async Task<bool> EditarMas(ModeloMascota obj_mascota)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);

            var contenido = new StringContent(JsonConvert.SerializeObject(obj_mascota), Encoding.UTF8, "application/json");
            var response = await clienteHttp.PutAsync($"api/Mascota/{obj_mascota.id}", contenido);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarMas(int id)
        {
            var clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri(_baseurl);
            var response = await clienteHttp.DeleteAsync($"api/Mascota/{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
