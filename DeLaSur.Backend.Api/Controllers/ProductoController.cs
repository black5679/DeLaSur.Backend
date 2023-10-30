using DeLaSur.Backend.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IScrapingService scrapingService; 
        public ProductoController(IScrapingService scrapingService)
        {
            this.scrapingService = scrapingService;
        }
        [HttpGet] public async Task<IActionResult> Get()
        {
            var productos = await scrapingService.CaratOnline();
            return Ok(productos);
        }
        [HttpPost]
        public async Task<IActionResult> RenderAsync()
        {
            try
            {
                // Ruta al ejecutable de Blender en tu servidor
                string blenderExecutablePath = @"C:\Program Files\Blender Foundation\Blender 3.5\blender.exe"; // Reemplaza con tu ruta

                // Ruta al archivo .blend que deseas renderizar (ruta hardcodeada)
                string blendFilePath = @"C:\Users\USER\Downloads\ring.blend"; // Reemplaza con tu ruta

                // Ruta completa del archivo de salida
                string outputImagePath = @"F:\output";

                // Configura los argumentos para Blender (ajusta según tus necesidades)
                string blenderArguments = $"-b \"{blendFilePath}\" -o \"{outputImagePath}\" -a --overwrite";

                await Task.Run(() =>
                {
                    // Configura el proceso de inicio
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = blenderExecutablePath,
                        Arguments = blenderArguments,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    // Inicia el proceso de Blender
                    using (Process process = new Process())
                    {
                        process.StartInfo = psi;
                        process.Start();

                    }
                });
                // Verifica si la imagen renderizada se guardó correctamente
                if (System.IO.File.Exists(outputImagePath))
                {
                    // Devuelve la ubicación de la imagen guardada en la respuesta HTTP
                    return Ok(new { ImagePath = "" });
                }
                else
                {
                    return BadRequest("La imagen renderizada no se guardó correctamente.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
