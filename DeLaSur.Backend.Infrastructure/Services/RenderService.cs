using Azure.Storage.Blobs;
using DeLaSur.Backend.Domain.Configuration;
using DeLaSur.Backend.Domain.Models;
using DeLaSur.Backend.Domain.Services;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace DeLaSur.Backend.Infrastructure.Services
{
    public class RenderService : IRenderService
    {
        private readonly StorageConfiguration storageConfiguration;
        private readonly BlobServiceClient blobServiceClient;
        private readonly HttpClient httpClient;
        public RenderService(IOptions<StorageConfiguration> storageConfiguration, BlobServiceClient blobServiceClient, HttpClient httpClient)
        {
            this.storageConfiguration = storageConfiguration.Value;
            this.blobServiceClient = blobServiceClient;
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
        public async Task Local(ModeloModel modelo, List<EspacioModel> espacios)
        {
            string localBlendDirectory = string.Concat("C:/Users/USER/OneDrive/Documentos/modelo/",modelo.IdMaterial);

            // Asegúrate de que el directorio exista
            if (!Directory.Exists(localBlendDirectory))
            {
                Directory.CreateDirectory(localBlendDirectory);
            }

            // Descarga el archivo .blend desde Azure Storage
            var containerClient = blobServiceClient.GetBlobContainerClient("modelo");
            var blobClient = containerClient.GetBlobClient(string.Concat(modelo.IdMaterial, "/", modelo.Id, modelo.Extension));
            var urlModelo = string.Concat(string.Concat("C:/Users/USER/OneDrive/Documentos/modelo/", modelo.IdMaterial, "/", modelo.Id, modelo.Extension));
            var blobDownloadInfo = blobClient.DownloadTo(urlModelo);
            // Ruta al ejecutable de Blender en tu servidor
            string colorHex = "#FF5733";
            // Convierte el color hexadecimal a componentes RGB
            var color = ColorTranslator.FromHtml(colorHex);
            float r = color.R / 255.0f;
            float g = color.G / 255.0f;
            float b = color.B / 255.0f;

            var psi = new ProcessStartInfo
            {
                FileName = @"C:\Program Files\Blender Foundation\Blender 3.5\blender.exe",
                Arguments = $"-b {urlModelo} --python-exit-code 1 --python-text \"InitScript.py\" -- {string.Join(",", espacios)} ",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (var process = new Process { StartInfo = psi })
            {
                process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data); // Capturar la salida de Blender
                process.ErrorDataReceived += (sender, e) => Console.WriteLine(e.Data); // Capturar errores, si los hay
                process.Start();
                process.BeginOutputReadLine(); // Iniciar la lectura de la salida en un hilo separado
                process.BeginErrorReadLine();  // Iniciar la lectura de errores en un hilo separado
                await process.WaitForExitAsync();
            }
        }
    }
}
