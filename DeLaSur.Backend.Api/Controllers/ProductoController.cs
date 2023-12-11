using DeLaSur.Backend.Domain.Services;
using DeLaSur.Backend.Infrastructure.Services;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;

namespace DeLaSur.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IScrapingService scrapingService;
        private readonly IRenderService renderService;
        public ProductoController(IScrapingService scrapingService, IRenderService renderService)
        {
            this.scrapingService = scrapingService;
            this.renderService = renderService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productos = await scrapingService.CaratOnline();
            return Ok(productos);
        }
        [HttpPost("Prueba")]
        public async Task<IActionResult> Prueba()
        {
            var response = await renderService.Render();
            return Ok(response);
        }
        //[HttpPost]
        //public async Task<IActionResult> RenderAsync()
        //{
        //    try
        //    {


        //        // Devolver la imagen renderizada como respuesta
        //        return PhysicalFile(outputImagePath, "image/png");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
