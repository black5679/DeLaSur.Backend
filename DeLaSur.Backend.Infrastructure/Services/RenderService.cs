using DeLaSur.Backend.Domain.Services;
using System.Net.Http;
using System.Text;

namespace DeLaSur.Backend.Infrastructure.Services
{
    public class RenderService : IRenderService
    {
        private readonly HttpClient httpClient;
        public RenderService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<dynamic> Render()
        {
            string apiUrl = "https://id.helio.exchange/auth/realms/helio/protocol/openid-connect/token";

            // Crear un objeto que contenga los datos que deseas enviar en el cuerpo
            var requestBody = new { grant_type = "password", scope = "openid", username = "black567_@hotmail.com", password = "jossimar2345*", client_id = "a72b9300-c4a3-4928-b830-e61b4265a394", client_secret = "" };

            // Convertir el objeto a formato JSON
            string jsonBody = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);

            // Crear un objeto StringContent para el cuerpo de la solicitud
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/x-www-form-urlencoded");

            // Añadir encabezados (si es necesario)
            //httpClient.DefaultRequestHeaders.Add("content-type", "application/x-www-form-urlencoded");

            // Realizar una solicitud POST a la API externa
            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

            // Verificar si la solicitud fue exitosa (código de estado 200-299)
            return response;
        }
    }
}
